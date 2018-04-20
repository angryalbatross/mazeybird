#pragma strict

public var randomBlockHolder : GameObject;
var randomBlocks = new Array();
var currentOppositeMapConnector : String = "none";


function Start () {
    var childrenBlocks : Component[]; 
    childrenBlocks = randomBlockHolder.GetComponentsInChildren(Transform, true);
    for (var thisChild : Transform in childrenBlocks) {
        if(thisChild.name.IndexOf("RandomBlock") >= 0) {
            randomBlocks.Add(thisChild.gameObject);
        }
    }
}

function Update () {
	
}

function OnTriggerEnter2D(coll : Collider2D) {
    if (coll.gameObject.tag == 'MapConnector') {
        if(coll.name.IndexOf('MapConnector_' + currentOppositeMapConnector  + '_') < 0) {
            Debug.Log('Triggered: ' + coll.name);
            Debug.Log('Index of opposite: ' + coll.name.IndexOf('MapConnector_' + currentOppositeMapConnector  + '_'));
            
            var blockToAdd : GameObject = randomBlocks[Random.Range(0,randomBlocks.length - 1)];
            var blockToAddOffset : Hashtable = getNewBlockOffset(coll.name);

            var newBlock = Instantiate(blockToAdd, blockToAddOffset['blockPosition'], coll.gameObject.transform.rotation);
        } 

        // Destroy collider so it doesn't trigger again
        Destroy(coll.gameObject);
    } 

}

function getNewBlockOffset(connectorName : String) : Hashtable {
    var resultHash : Hashtable = new Hashtable();
    var nameArray : String[];
    nameArray = connectorName.Split("_"[0]);

    var blockPosition : Vector3;
    switch (nameArray[1]) {
        case 'bot':
            blockPosition = Vector3(0.0, -20.0);
            resultHash.Add('opposite', 'top');
            break;
        case 'top':
            blockPosition = Vector3(0.0, 20.0);
            resultHash.Add('opposite', 'bot');
            break;
        case 'left':
            blockPosition = Vector3(-20.0, 0.0);
            resultHash.Add('opposite', 'right');
            break;
        case 'right':
            blockPosition = Vector3(20.0, 0.0);
            resultHash.Add('opposite', 'left');
            break;
        }
    resultHash.Add('blockPosition', blockPosition);
    currentOppositeMapConnector = resultHash['opposite'];
    Debug.Log('Current Opposite: ' + currentOppositeMapConnector);
    return resultHash;
}
    
