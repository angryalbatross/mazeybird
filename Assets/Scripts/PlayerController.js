#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
var health : int = 100;
var slider : UI.Slider;
var animationController : GameObject;
var totalMoney : int;
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
    if(controlsEnabled) {
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
	if(health - amount < 0)
		YouLose();
	else {
		Debug.Log("you took some damage");
		health -= amount;
		slider.value = health;
	}
		
}

function GainMoney (amount : int, coin : GameObject){
    totalMoney += 1;
    coin.SetActive(false);
    Debug.Log("your total gold collected is = " + totalMoney);
}

function YouWin () {
    Debug.Log("YOU WON!");
}

function YouLose () {
    controlsEnabled = false;
    Debug.Log("You Lost :( :( :(");
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
    }

function FixedUpdate()
{
	GetComponent.<Rigidbody2D>().velocity = movement;
}