#pragma strict

public var randomBlockHolder : GameObject;
var randomBlocks = new Array();


function Start () {
    var childrenBlocks : Component[]; 
    childrenBlocks = randomBlockHolder.GetComponentsInChildren(Transform, true);
    for (var thisChild : Transform in childrenBlocks) {
        if(thisChild.gameObject.name.IndexOf("RandomBlock") >= 0) {
            randomBlocks.Add(thisChild.gameObject);
        }
    }
    Debug.Log(randomBlocks);
}

function Update () {
	
}

function OnCollisionEnter2D(coll : Collision2D) {
    Debug.Log(coll.gameObject.name);



    // var thisBlock = [Random.Range(0,arrayOfBlocks.length - 1)];
    // Instantiate(thisBlock, coll.gameObject.transform);
}
    
