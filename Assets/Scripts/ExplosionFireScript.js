#pragma strict

//From this tutorial https://youtu.be/-5MZLxbGHSM
var explosion_delay : float = 1f;
var explosion_speed : float = 1f;

var exploded : boolean = false;
var explosion_radius : CircleCollider2D;

function Start () {
	explosion_radius = gameObject.GetComponent.<CircleCollider2D>();

}

function Update () {
	explosion_delay -= Time.deltaTime;
	if(explosion_delay < 0)
		{
			exploded = true;
		}
}

function FixedUpdate () {
	if (exploded == true)
	{
		explosion_radius.radius = explosion_radius.radius + explosion_speed;
	}
}

function OnTriggerStay2D (coll : Collider2D) {
    if (coll.gameObject.tag == "Player")
		{
			// coll.gameObject.SendMessage("TakeDamage", 5.0);
			Debug.Log('Player took 5 damage!');
		}
		if (coll.gameObject.tag == "FireEffects")
		{
			// SpriteRend = coll.gameObject.GetComponent<SpriteRenderer>();
			// SpriteRend.enabled = true;
		}
  }
