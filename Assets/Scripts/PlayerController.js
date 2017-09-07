#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
var health : int = 100;
var mainCamera : GameObject;
var mapCamera : GameObject;
var mapOffButton : GameObject;
var animationController : GameObject;
var deadSprite : GameObject;
var totalMoney : int;
var youDied : GameObject;
var youWon : GameObject;
var youRanOutOfLives : GameObject;
var panSpeed : float = 3F;
var touchControlsEnabled = false;
private var isInvincible : boolean = false;
private var rb : Rigidbody2D;
private var movement : Vector2;
private var animator : Animator;
private var controlsEnabled : boolean = true;
private var lives : int;

function Start () {
  var initialLoad = PlayerPrefs.GetInt("initialLoad");
  if(initialLoad == 0) {
    //Flag the first time the player loads the game.
    PlayerPrefs.SetInt("initialLoad", 1);
  }
  lives = PlayerPrefs.GetInt('lives');
  animator = animationController.GetComponent.<Animator>();
	rb = this.GetComponent.<Rigidbody2D>();
	totalMoney = 0;
  showMap();
}

function Update()
{
    if(controlsEnabled && !isInvincible) {
        var inputX : float = Input.GetAxis("Horizontal");
        var inputY : float = Input.GetAxis("Vertical");

      	//touch controls  -------------------------------------
      	if(touchControlsEnabled)
      	{
      		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
    	    {
      	     var touchDeltaPosition : Vector2 = Input.GetTouch(0).deltaPosition;
      	  	 var touchInputX : float = (touchDeltaPosition.x * panSpeed)/8;
      			 var touchInputY : float = (touchDeltaPosition.y * panSpeed)/8;

             if (touchInputX > 0)
             {
               animator.SetInteger("Direction", 0);
             }
             else if (touchInputX < 0)
             {
               animator.SetInteger("Direction", 1);
             }

      			 movement = Vector2(
      			      speed.x * touchInputX,
      			      speed.y * touchInputY);
    	    } else { //don't move unless being touched
    	    	movement = Vector2(0,0);
    	    }


      	    //end touch controlls -------------------------------
      	} else {
          //keyboard controlls-------------------------------------
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
    deadSprite.SetActive(true);
    animationController.SetActive(false);
    controlsEnabled = false;
    isInvincible = true;
    lives -= 1;
    if(lives == 0) {
      //the player is out of lives and needs to wait 24 hours or watch an ad!
      youRanOutOfLives.SetActive(true);
      PlayerPrefs.SetInt('lives', lives);
      PlayerPrefs.SetString("lastLifeLostDate", System.DateTime.Now.ToString());
    } else {
      //show 'you died' menu so user can reset the level
      youDied.SetActive(true);
      PlayerPrefs.SetInt('lives', lives);
    }
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
  mapOffButton.SetActive(true);

  GetComponent.<Rigidbody2D>().gravityScale = 0;
}

function hideMap() {
  GetComponent.<Rigidbody2D>().gravityScale = 2;
  //swap map buttons
  mapOffButton.SetActive(false);
  //swap cameras
  mainCamera.SetActive(true);
  mapCamera.SetActive(false);
  //turn on controlls
  controlsEnabled = true;
}
