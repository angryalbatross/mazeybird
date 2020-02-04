using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ExplosionFireScript : MonoBehaviour
{
    public float fire_delay;
    public bool onFire;
    public GameObject fireSpriteController;
    public GameObject player;
    private int fireCounter; //a counter to track if we have set the player on fire from this object
    public virtual void FixedUpdate()
    {
        this.fire_delay = this.fire_delay - Time.deltaTime;
        if (!this.onFire && (this.fire_delay <= 0))
        {
            this.onFire = true;
            this.fireSpriteController.SetActive(true);
        }
        if (this.onFire)
        {
            //check if we are on fire, player is inside our trigger and we haven't already set them on fire
            if ((this.player != null) && (this.fireCounter == 0))
            {
                this.player.GetComponent<PlayerController>().onFire = this.player.GetComponent<PlayerController>().onFire + 1;
                this.fireCounter = this.fireCounter + 1;
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.player = other.gameObject;
            this.player.GetComponent<PlayerController>().escaped = this.player.GetComponent<PlayerController>().escaped + 1;
        }
        if (this.onFire)
        {
             //set the player on fire
            this.player.GetComponent<PlayerController>().onFire = this.player.GetComponent<PlayerController>().onFire + 1;
            this.fireCounter = this.fireCounter + 1;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.player.GetComponent<PlayerController>().escaped = this.player.GetComponent<PlayerController>().escaped - 1;
            if (this.onFire)
            {
                this.player.GetComponent<PlayerController>().onFire = this.player.GetComponent<PlayerController>().onFire - 1;
                this.fireCounter = this.fireCounter - 1;
            }
            this.player = null;
        }
    }

    public ExplosionFireScript()
    {
        this.fire_delay = 1f;
    }

}