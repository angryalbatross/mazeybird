using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class activateTrap : MonoBehaviour
{
    public GameObject[] linkedObjects;
    private bool activated;
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (this.activated)
            {
                //we are already activated so deactivate this trap/door/object
                this.deactivateGameObjects();
            }
            else
            {
                //we are deactivated so we must be activated
                this.activateGameObjects();
            }
        }
    }

    public virtual void activateGameObjects()
    {
        foreach (GameObject linkedObject in this.linkedObjects)
        {
            linkedObject.SetActive(true);
            linkedObject.SendMessage("activate", SendMessageOptions.DontRequireReceiver);
        }
        this.activated = true;
    }

    public virtual void deactivateGameObjects()
    {
        foreach (GameObject linkedObject in this.linkedObjects)
        {
            linkedObject.SetActive(false);
            linkedObject.SendMessage("deactivate", SendMessageOptions.DontRequireReceiver);
        }
        this.activated = false;
    }

}