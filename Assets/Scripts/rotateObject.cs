using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class rotateObject : MonoBehaviour
{
    public int degreesPerSec;
    public virtual void Update()
    {
        this.transform.Rotate(0, 0, this.degreesPerSec * Time.deltaTime); //rotates 50 degrees per second around z axis
    }

    public rotateObject()
    {
        this.degreesPerSec = 15;
    }

}