using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class changeSprite : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Sprite currentSprite = ((SpriteRenderer) this.GetComponent(typeof(SpriteRenderer))).sprite;
            if (currentSprite == this.sprite1)
            {
                ((SpriteRenderer) this.GetComponent(typeof(SpriteRenderer))).sprite = this.sprite2;
            }
            else
            {
                ((SpriteRenderer) this.GetComponent(typeof(SpriteRenderer))).sprite = this.sprite1;
            }
        }
    }

}