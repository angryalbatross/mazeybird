using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class disappearingDoor : MonoBehaviour
{
    private bool activated;
    public virtual void FixedUpdate()
    {
        if (this.activated)
        {
            this.gameObject.SetActive(false);
        }
    }

    public virtual void activate()
    {
        this.activated = true;
    }

}