#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
var health : int = 100;
var mainCamera : GameObject;
var mapCamera : GameObject;
var mapOnButton : GameObject;
var mapOffButton : GameObject;
var startButton : GameObject;
var animationController : GameObject;
var deadSprite : GameObject;
var totalMoney : int;
var youDied : GameObject;
var youWon : GameObject;
private var isInvincible : boolean = false;
private var rb : Rigidbody2D;
private var movement : Vector2;
private var animator : Animator;
private var controlsEnabled : boolean = true;
private var isStart : boolean = true;

function Start () {
  animator = animationController.GetComponent.<Animator>();
	rb = this.GetComponent.<Rigidbody2D>();
	totalMoney = 0;
  showMap();
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
    deadSprite.SetActive(true);
    animationController.SetActive(false);
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
  if(controlsEnabled) {
    GetComponent.<Rigidbody2D>().velocity = movement;
  } else {
    GetComponent.<Rigidbody2D>().velocity = Vector2(0,0);
  }
}

function showMap() {
  // turn off controlsEnabled
  controlsEnabled = false;
  // swap cameras
  mapCamera.SetActive(true);
  mainCamera.SetActive(false);
  // show the hide map button
  if(isStart) {
    startButton.SetActive(true);
  } else {
    mapOffButton.SetActive(true);
  }
  mapOnButton.SetActive(false);

  GetComponent.<Rigidbody2D>().gravityScale = 0;
}

function hideMap() {
  GetComponent.<Rigidbody2D>().gravityScale = 2;
  //swap map buttons
  mapOnButton.SetActive(true);
  if(isStart) {
    startButton.SetActive(false);
  } else {
    mapOffButton.SetActive(false);
  }
  isStart = false;
  //swap cameras
  mainCamera.SetActive(true);
  mapCamera.SetActive(false);
  //turn on controlls
  controlsEnabled = true;
}
