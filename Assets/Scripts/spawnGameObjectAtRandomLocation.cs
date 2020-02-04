using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class spawnGameObjectAtRandomLocation : MonoBehaviour
{
    public GameObject gameObjectToSpawn;
    public GameObject[] arrayOfPoints;
    public virtual void Start()
    {
        Vector3 spawnPointLocation = this.arrayOfPoints[Random.Range(0, this.arrayOfPoints.length - 1)].transform.position;
        UnityEngine.Object.Instantiate(this.gameObjectToSpawn, spawnPointLocation, Quaternion.identity);
    }

}