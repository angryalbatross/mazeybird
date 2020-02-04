#pragma strict

var fire_delay : float = 1f;
var onFire : boolean = false;
var fireSpriteController : GameObject = null;
var player : GameObject = null;
private var fireCounter : int = 0; //a counter to track if we have set the player on fire from this object

function FixedUpdate () 
{
	fire_delay -= Time.deltaTime;
	if(!onFire && fire_delay <= 0)
	{
		onFire = true;
		fireSpriteController.SetActive(true);
	}

	if(onFire){
		//check if we are on fire, player is inside our trigger and we haven't already set them on fire
		if(player != null && fireCounter == 0)
		{
			player.GetComponent.<PlayerController>().onFire += 1;
			fireCounter += 1;
		}
	}
}

function OnTriggerEnter2D(other: Collider2D)
{
	if(other.gameObject.tag == "Player")
	{
		player = other.gameObject;
		player.GetComponent.<PlayerController>().escaped += 1;
	}
	if(onFire)
    {
			//set the player on fire
			player.GetComponent.<PlayerController>().onFire += 1;
			fireCounter += 1;
    }
}

function OnTriggerExit2D(other: Collider2D)
{
    if(other.gameObject.tag == "Player")
    {
		player.GetComponent.<PlayerController>().escaped -= 1;
		if(onFire) {
			player.GetComponent.<PlayerController>().onFire -= 1;
			fireCounter -=1;
		}
		player = null;
    }
}