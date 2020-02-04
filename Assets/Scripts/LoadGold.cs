using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class LoadGold : MonoBehaviour
{
    public int gold;
    public virtual void OnEnable()
    {
        this.gold = PlayerPrefs.GetInt("gold");
        this.GetComponent<UnityEngine.UI.Text>().text = this.gold.ToString();
    }

    public LoadGold()
    {
        this.gold = 1;
    }

}