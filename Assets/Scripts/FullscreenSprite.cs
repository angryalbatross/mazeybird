using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class FullscreenSprite : MonoBehaviour
{
    public Camera chosenCamera;
    public virtual void Awake()
    {
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        float cameraHeight = this.chosenCamera.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(this.chosenCamera.aspect * cameraHeight, cameraHeight);
        Vector3 spriteSize = spriteRenderer.sprite.bounds.size;
        Vector3 scale = this.transform.localScale;
        Debug.Log(scale);
        Debug.Log(cameraSize.x);
        Debug.Log(cameraSize.y);
        Debug.Log(spriteSize.x);
        Debug.Log(spriteSize.y);
        if (cameraSize.x >= cameraSize.y)
        {
            scale = scale * (cameraSize.x / spriteSize.x);
        }
        else
        {
            scale = scale * (cameraSize.y / spriteSize.y);
        }
        Debug.Log(scale);
        this.transform.localScale = scale;
    }

}