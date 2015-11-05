#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
private var rb : Rigidbody2D;
private var lightSource;
private var movement : Vector2;

function Start () {
	 rb = this.GetComponent.<Rigidbody2D>();
	 lightSource = this.transform.Find("LightSource");
}

function Update()
{
	//keyboard controlls-------------------------------------
	var inputX : float = Input.GetAxis("Horizontal");
	var inputY : float = Input.GetAxis("Vertical");
//	if(spotLightEnabled == true)
//	{
//		if(inputX > 0) //we are moving up
//			lightSource.transform.Rotate(270);
//		else if(inputY > 0) //we are moving right
//			lightSource.transform.Rotate(180);
//		else if(inputX < 0) //we are moving down
//			lightSource.transform.Rotate(90);
//		else if(inputY < 0) //we are moving right
//			lightSource.transform.Rotate(0);
//	}

	movement = Vector2(
      speed.x * inputX,
      speed.y * inputY);
    //end keyboard controlls -----------------------------  
}

function FixedUpdate()
{
	GetComponent.<Rigidbody2D>().velocity = movement;
}