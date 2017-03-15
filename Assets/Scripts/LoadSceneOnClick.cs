using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour {

    public GameObject notEnoughGoldAlert;
    public int goldTillUnlocked = 0;
    public int thisLevelNumber = 0;
    private bool levelIsUnlocked = false;

    public void LoadByIndex(int sceneIndex)
    {
        levelIsUnlocked = isLevelUnlocked();
        var currentMoney = PlayerPrefs.GetInt("gold");
        if(levelIsUnlocked) {
          // load the level
          SceneManager.LoadScene (sceneIndex);
        } else {
          if(currentMoney >= goldTillUnlocked ){
            currentMoney -= goldTillUnlocked;
            PlayerPrefs.SetInt("gold", currentMoney);
            PlayerPrefs.SetInt("maxLevelUnlocked", thisLevelNumber);
            SceneManager.LoadScene (sceneIndex);
          } else {
            // show alert saying you don't have enough gold?
            notEnoughGoldAlert.SetActive(true);
          }
        }

    }

    private bool isLevelUnlocked(){
      var maxLevelUnlocked = PlayerPrefs.GetInt("maxLevelUnlocked");
      if(maxLevelUnlocked >= thisLevelNumber) {
        //this level must have been unlocked so return true
        return true;
      } else {
        return false;
      }
    }
}
