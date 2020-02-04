#pragma strict

public var MapConnector_top_left : GameObject[];
public var MapConnector_top_mid : GameObject[];
public var MapConnector_top_right : GameObject[];
public var MapConnector_bot_left: GameObject[];
public var MapConnector_bot_mid : GameObject[];
public var MapConnector_bot_right : GameObject[];
public var MapConnector_right_mid : GameObject[];
public var MapConnector_left_mid : GameObject[];
public var blocksToConnectorsMap : Hashtable = new Hashtable();
public var player : GameObject;
blocksToConnectorsMap['MapConnector_top_left'] = MapConnector_top_left;
blocksToConnectorsMap['MapConnector_top_mid'] = MapConnector_top_mid;
blocksToConnectorsMap['MapConnector_top_right'] = MapConnector_top_right;
blocksToConnectorsMap['MapConnector_bot_left'] = MapConnector_bot_left;
blocksToConnectorsMap['MapConnector_bot_mid'] = MapConnector_bot_mid;
blocksToConnectorsMap['MapConnector_bot_right'] = MapConnector_bot_right;
blocksToConnectorsMap['MapConnector_right_mid'] = MapConnector_right_mid;
blocksToConnectorsMap['MapConnector_left_mid'] = MapConnector_left_mid;
private var currentMapConnectorOpposite : String = "none";
private var currentMapConnectorSecondDimension : String = "none";


function Start () {
    // var thisData : Hashtable = new Hashtable();
    // var holderChildren : Transform[] = randomBlockHolder.GetComponentsInChildren.<Transform>(true);
    
    // for (var thisBlock : Transform in holderChildren) {
    //     if(thisBlock.tag == 'MapBlock') {
    //         Debug.Log('This block: ' + thisBlock.name);
    //         var mapConnectors : Transform[] = thisBlock.GetComponentsInChildren.<Transform>(true);
    //         var mapConnectorNames = new Array();
    //         for (var thisConnector : Transform in mapConnectors) {
    //             if(thisConnector.tag == 'MapConnector') {
    //                 Debug.Log('This connector name: ' + thisConnector.name);
    //                 Debug.Log('This connector tag: ' + thisConnector.tag);
    //                 mapConnectorNames.Push(thisConnector.name);
    //             }
    //         }
    //     }
    // }
}

function Update () {
	
}

function OnTriggerEnter2D(coll : Collider2D) {
    if (coll.gameObject.tag == 'MapConnector') {
        if(coll.name.IndexOf('MapConnector_' + currentMapConnectorOpposite  + '_') < 0) {
            Debug.Log('Triggered: ' + coll.name);
            Debug.Log('Index of opposite: ' + coll.name.IndexOf('MapConnector_' + currentMapConnectorOpposite  + '_'));
            
            var blockToAddOffset : Hashtable = getNewBlockOffset(coll.name);
            var blockToAddPostion : Vector3 = blockToAddOffset['blockPosition'];
            var blockToAdd : GameObject = getBlockWithMatchingConnector(coll.name);
            
            var newBlock = Instantiate(blockToAdd, coll.gameObject.transform.position + blockToAddPostion, coll.gameObject.transform.rotation);
        } 

        // Destroy collider so it doesn't trigger again
        Destroy(coll.gameObject);
        //Debug.Break();
    } 

}

function getNewBlockOffset(connectorName : String) : Hashtable {
    var resultHash : Hashtable = new Hashtable();
    var nameArray : String[];
    nameArray = connectorName.Split("_"[0]);

    var blockPosition : Vector3;
    switch (nameArray[1]) {
        case 'bot':
            blockPosition = Vector3(0.0, -10.0);
            resultHash.Add('opposite', 'top');
            break;
        case 'top':
            blockPosition = Vector3(0.0, 10.0);
            resultHash.Add('opposite', 'bot');
            break;
        case 'left':
            blockPosition = Vector3(-10.0, 0.0);
            resultHash.Add('opposite', 'right');
            break;
        case 'right':
            blockPosition = Vector3(10.0, 0.0);
            resultHash.Add('opposite', 'left');
            break;
        }
    resultHash.Add('blockPosition', blockPosition);
    currentMapConnectorSecondDimension = nameArray[2];
    currentMapConnectorOpposite = resultHash['opposite'];
    Debug.Log('Current Opposite: ' + currentMapConnectorOpposite);
    return resultHash;
}

function getBlockWithMatchingConnector(connectorName : String) : GameObject {
    Debug.Log('getBlockWithMatchingConnector: ' + connectorName);
    var thisConnectorOptions : GameObject[] = blocksToConnectorsMap[connectorName];
    Debug.Log('thisConnectorOptions.length: ' + thisConnectorOptions.length);
    return thisConnectorOptions[Random.Range(0, thisConnectorOptions.length - 1)];
}
    
