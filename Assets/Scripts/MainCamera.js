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
        Debug.Log(getNewBlockOffset(coll.gameObject.name));
        
        var blockToAdd : GameObject = randomBlocks[Random.Range(0,randomBlocks.length - 1)];
        var blockToAddOffset : Hashtable = getNewBlockOffset(coll.gameObject.name);
        var blockToAddChildren : Component[] = blockToAdd.GetComponentsInChildren(Transform, true);

        // Destroy map connectors that are inbetween the existing block, and the new block
        for (var thisChild : Transform in blockToAddChildren) {
            if(thisChild.gameObject.name.IndexOf('_' + blockToAddOffset['opposite'] + '_') > 0) {
                Destroy(thisChild.gameObject);
            }
        }

        var newBlock = Instantiate(blockToAdd, blockToAddOffset['blockPosition'], coll.gameObject.transform.rotation);
        newBlock.SetActive(true);
        Destroy(coll.gameObject);
    }
}

function getNewBlockOffset(connectorName : String) : Hashtable {
    var result : Hashtable;
    var nameArray : String[];
    nameArray = connectorName.Split("_"[0]);
    Debug.Log(nameArray[0]);

    var blockPosition : Vector3;
    switch (nameArray[1]) {
        case 'bot':
            blockPosition = Vector3(0.0, -20.0);
            result.Add('opposite', 'top');
            break;
        case 'top':
            blockPosition = Vector3(0.0, 20.0);
            result.Add('opposite', 'bot');
            break;
        case 'left':
            blockPosition = Vector3(-20.0, 0.0);
            result.Add('opposite', 'right');
            break;
        case 'right':
            blockPosition = Vector3(20.0, 0.0);
            result.Add('opposite', 'left');
            break;
    }
    result.Add('blockPosition', blockPosition);
    return result;
}

    // var thisBlock = [Random.Range(0,arrayOfBlocks.length - 1)];
    // Instantiate(thisBlock, coll.gameObject.transform);
    
