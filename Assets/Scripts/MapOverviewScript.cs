using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapOverviewScript : MonoBehaviour
{
    public GameObject startMarker;
    public GameObject endMarker;
    // Movement speed in units/sec.
    public float speed;
    // Time when the movement started.
    private float startTime;
    private Vector3 startLocation;
    private Vector3 endLocation;
    private float zHeight;
    // Total distance between the markers.
    private float journeyLength;
    public virtual void Awake()
    {
        // Keep a note of the time the movement started.
        this.startTime = Time.time;
        this.zHeight = this.transform.position.z;
        this.startLocation = new Vector3(this.startMarker.transform.position.x, this.startMarker.transform.position.y, this.zHeight);
        this.endLocation = new Vector3(this.endMarker.transform.position.x, this.endMarker.transform.position.y, this.zHeight);
        // Calculate the journey length.
        this.journeyLength = Vector3.Distance(this.startLocation, this.endLocation);
    }

    // Follows the target position like with a spring
    public virtual void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - this.startTime) * this.speed;
        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / this.journeyLength;
        // Set our position as a fraction of the distance between the markers.
        this.transform.position = Vector3.Lerp(this.startLocation, this.endLocation, fracJourney);
    }

    public MapOverviewScript()
    {
        this.speed = 1f;
        this.startLocation = new Vector3(0, 0, 0);
        this.endLocation = new Vector3(0, 0, 0);
    }

}