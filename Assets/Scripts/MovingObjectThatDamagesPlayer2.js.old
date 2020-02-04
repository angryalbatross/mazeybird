#pragma strict
var startMarker : GameObject;
var endMarker : GameObject;

// Movement speed in units/sec.
var speed = 1.0;
var myDamage : int = 10;

// Time when the movement started.
private var startTime: float;
private var startLocation : Vector3 = Vector3(0,0,0);
private var endLocation : Vector3 =  Vector3(0,0,0);
private var zHeight : float;

// Total distance between the markers.
private var journeyLength: float;

function Awake() {
		// Keep a note of the time the movement started.
		startTime = Time.time;
		zHeight = this.transform.position.z;
		startLocation = Vector3(startMarker.transform.position.x, startMarker.transform.position.y,zHeight);
		endLocation = Vector3(endMarker.transform.position.x, endMarker.transform.position.y,zHeight);

		// Calculate the journey length.
		journeyLength = Vector3.Distance(startLocation, endLocation);
}

// Follows the target position like with a spring
function Update () {
		// Distance moved = time * speed.
		var distCovered = (Time.time - startTime) * speed;

		// Fraction of journey completed = current distance divided by total distance.
		var fracJourney = distCovered / journeyLength;

		// Set our position as a fraction of the distance between the markers.
		transform.position = Vector3.Lerp(startLocation, endLocation, fracJourney);
}

function OnTriggerEnter2D(coll : Collider2D) {
	if (coll.gameObject.tag == "Player")
    coll.gameObject.SendMessage("TakeDamage", myDamage);
}
