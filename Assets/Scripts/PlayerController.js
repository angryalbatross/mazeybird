﻿#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
var health : int = 100;
var animationController : GameObject;
var totalMoney : int;
var youDied : GameObject;
var youWon : GameObject;
private var isInvincible : boolean = false;
private var rb : Rigidbody2D;
private var movement : Vector2;
private var animator : Animator;
private var controlsEnabled : boolean = true;

function Start () {
    animator = animationController.GetComponent.<Animator>();
	rb = this.GetComponent.<Rigidbody2D>();
	totalMoney = 0;
}

function Update()
{
    if(controlsEnabled && !isInvincible) {
        //keyboard controlls-------------------------------------
        var inputX : float = Input.GetAxis("Horizontal");
        var inputY : float = Input.GetAxis("Vertical");

        if (inputX > 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (inputX < 0)
        {
            animator.SetInteger("Direction", 1);
        }

        movement = Vector2(
          speed.x * inputX,
          speed.y * inputY);
        //end keyboard controlls -----------------------------
    }
}

function TakeDamage (amount : int){
  if(!isInvincible){
    if(health - amount < 0)
      YouLose();
    else {
      Debug.Log("you took some damage");
      health -= amount;
    }
  }
}

function GainMoney (amount : int, coin : GameObject){
    totalMoney += 1;
    coin.SetActive(false);
    Debug.Log("your total gold collected is = " + totalMoney);
}

function YouWin () {
    Debug.Log("YOU WON!");
    isInvincible = true;
    var currentMoney = PlayerPrefs.GetInt("gold");
    PlayerPrefs.SetInt("gold", totalMoney + currentMoney);
    PlayerPrefs.SetInt("lastLevelLoaded", 0);
    PlayerPrefs.Save();
    var lastLevelLoaded = PlayerPrefs.GetInt("lastLevelLoaded");
    Debug.Log("lastLevelLoaded was = " + lastLevelLoaded);
    youWon.SetActive(true);
    controlsEnabled = false;
}

function YouLose () {
    youDied.SetActive(true);
    controlsEnabled = false;
    Debug.Log("You Lost :( :( :(");
    isInvincible = true;
}


function OnCollisionEnter2D(coll : Collision2D) {
    if (coll.gameObject.tag == "thornWall")
        TakeDamage(20);
    else if (coll.gameObject.tag == "gold")
        GainMoney(1, coll.gameObject);
    else if (coll.gameObject.tag == "nest")
        YouWin();
    else if (coll.gameObject.tag == "emptyNest")
        YouLose();
        //you shouldn't lose, you just should have to find the real one?
    }

function FixedUpdate()
{
	GetComponent.<Rigidbody2D>().velocity = movement;
}
