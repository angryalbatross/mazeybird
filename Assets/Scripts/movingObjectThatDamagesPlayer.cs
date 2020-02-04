using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class movingObjectThatDamagesPlayer : MonoBehaviour
{
    public float mySpeed;
    public int myDamage;
    public GameObject startLocation;
    public GameObject endLocation;
    private bool activated;
    public virtual void FixedUpdate()//this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position.Vector2, endLocation.transform.position.Vector2, mySpeed);
    {
        if (this.activated)
        {
        }
    }

    public virtual void Update()
    {
        // The step size is equal to speed times frame time.
        float step = this.mySpeed * Time.deltaTime;
        // Move our position a step closer to the target.
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.endLocation.transform.position, step);
    }

    public virtual void activate()
    {
        this.activated = true;
    }

    public virtual void deactivate()
    {
        this.activated = false;
        this.gameObject.transform.position = this.startLocation.transform.position;
    }

    public movingObjectThatDamagesPlayer()
    {
        this.mySpeed = 10;
        this.myDamage = 10;
    }

}