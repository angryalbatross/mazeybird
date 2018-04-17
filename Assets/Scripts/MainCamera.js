#pragma strict

public var randomBlocks : GameObject;


function Start () {
    var childrenBlocks: Component[]; 
    childrenBlocks = randomBlocks.GetComponentsInChildren(Transform, true);
    for (var thisChild : Transform in childrenBlocks) {
        if(thisChild.gameObject.name.IndexOf("RandomBlock") >= 0) {
            Debug.Log(thisChild);
        }
    }
}

function Update () {
	
}

function OnCollisionEnter2D(coll : Collision2D) {
    Debug.Log(coll.gameObject.name);



    // var thisBlock = [Random.Range(0,arrayOfBlocks.length - 1)];
    // Instantiate(thisBlock, coll.gameObject.transform);
}
    
