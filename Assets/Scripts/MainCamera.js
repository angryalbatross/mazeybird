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

function OnTriggerEnter2D(coll : Collider2D) {
    if (coll.gameObject.tag == 'MapConnector') {
        Debug.Log(coll.gameObject.name);
        getNewBlockOffset(coll.gameObject.name);

        var blockToAdd : GameObject = randomBlocks[Random.Range(0,randomBlocks.length - 1)];
        var newBlock = Instantiate(blockToAdd, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
        newBlock.SetActive(true);
        Destroy(coll.gameObject);
    }
}

function getNewBlockOffset(connectorName : String) {
    var nameArray : String[];
    nameArray = connectorName.Split("_"[0]);
    Debug.Log(nameArray[0]);

    switch (nameArray[1]) {
    }
}

    // var thisBlock = [Random.Range(0,arrayOfBlocks.length - 1)];
    // Instantiate(thisBlock, coll.gameObject.transform);
    
