using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LoadLives : MonoBehaviour
{
    public int lives;
    public virtual void OnEnable()
    {
        this.lives = PlayerPrefs.GetInt("lives");
        this.GetComponent<UnityEngine.UI.Text>().text = this.lives.ToString();
    }

}