#pragma strict

private var activated : boolean = false;

function FixedUpdate () {
	if(activated)
		this.gameObject.SetActive(false);
}

function activate() {
	activated = true;
}
