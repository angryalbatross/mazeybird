#pragma strict

var speed : Vector2 = Vector2(50,50);
var spotLightEnabled : boolean = false;
var health : int = 100;
var slider : UI.Slider;
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

function Die(){
	Debug.Log("you died");
}

function TakeDamage (amount : int){
	if(health - amount < 0)
		Die();
	else {
		Debug.Log("you took some damage");
		health -= amount;
		slider.value = health;
	}
		
}


function OnCollisionEnter2D(coll : Collision2D) {
        if (coll.gameObject.tag == "thornWall")
            TakeDamage(20);
        
    }

function FixedUpdate()
{
	GetComponent.<Rigidbody2D>().velocity = movement;
}