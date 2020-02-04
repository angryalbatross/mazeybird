var mySpeed : float = 10;
var myDamage : int = 10;
var startLocation : GameObject;
var endLocation : GameObject;

private var activated : boolean = false;

function FixedUpdate () {
	if(activated){
		//this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position.Vector2, endLocation.transform.position.Vector2, mySpeed);
	}
}

function Update () {
      // The step size is equal to speed times frame time.
      var step = mySpeed * Time.deltaTime;

      // Move our position a step closer to the target.
      transform.position = Vector2.MoveTowards(transform.position, endLocation.transform.position, step);
  }

function activate() {
	activated = true;
}

function deactivate() {
	activated = false;
	this.gameObject.transform.position = startLocation.transform.position;
}
