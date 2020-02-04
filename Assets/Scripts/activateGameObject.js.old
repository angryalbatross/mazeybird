#pragma strict

public var linkedObjects : GameObject[];
private var activated : boolean = false;

function OnCollisionEnter2D(coll : Collision2D) {
	if (coll.gameObject.tag == "Player")
    {
    	if(activated) {
    		//we are already activated so deactivate this trap/door/object
    		deactivateGameObjects();
    	} else {
    		//we are deactivated so we must be activated
    		activateGameObjects();
    	}
    }
}

function activateGameObjects () {
	for(var linkedObject : GameObject in linkedObjects)
	{
		linkedObject.SendMessage("activate", SendMessageOptions.DontRequireReceiver);
	}
	activated = true;
}

function deactivateGameObjects () {
	for(var linkedObject : GameObject in linkedObjects)
	{
		linkedObject.SendMessage("deactivate", SendMessageOptions.DontRequireReceiver);
	}
	activated = false;
}
