using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    var goldTillUnlocked = 0;
    public void LoadByIndex(int sceneIndex)
    {
        var currentMoney = PlayerPrefs.GetInt("gold");
        if(currentMoney >= goldTillUnlocked ){
            currentMoney -= goldTillUnlocked;
            PlayerPrefs.SetInt("gold", currentMoney);
            SceneManager.LoadScene (sceneIndex);
        } else {
          // show alert saying you don't have enough gold?
        }
    }
}
