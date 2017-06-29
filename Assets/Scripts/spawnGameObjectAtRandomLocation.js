#pragma strict

public var gameObjectToSpawn : GameObject;
public var arrayOfPoints : GameObject[];

function Start () {
	var spawnPointLocation = arrayOfPoints[Random.Range(0,arrayOfPoints.length - 1)].transform.position;
	Instantiate(gameObjectToSpawn, spawnPointLocation, Quaternion.identity);
}
