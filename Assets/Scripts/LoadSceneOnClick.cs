using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour {

    public GameObject notEnoughGoldAlert;
    public GameObject unlockPreviousLevelAlert;
    public GameObject unlockedLevelImage;
    public GameObject watchAdOrWaitAlert;
    //public GameObject gold;
    public int goldTillUnlocked = 0;
    public int thisLevelNumber = 0;
    public bool levelIsUnlocked = false;
    private int maxLevelUnlocked = 0;
    private int lives = 0;

    public void Start () {
      maxLevelUnlocked = PlayerPrefs.GetInt("maxLevelUnlocked");
      if(maxLevelUnlocked >= thisLevelNumber) {
        //this level must have been unlocked so return true and hide the X
        if(unlockedLevelImage != null) {
          unlockedLevelImage.SetActive(false);
        }
        levelIsUnlocked = true;
      }
      lives = PlayerPrefs.GetInt("lives");
    }

    public void LoadByIndex(int sceneIndex)
    {
        var currentMoney = PlayerPrefs.GetInt("gold");
        if(levelIsUnlocked) {
          // load the level if the player has enough lives
          if(lives > 0){
            SceneManager.LoadScene (sceneIndex);
          } else {
            //show alert to the user
            watchAdOrWaitAlert.SetActive(true);
          }
        } else {
          //first check to make sure the previous level has been unlocked
          if (PlayerPrefs.GetInt("maxLevelUnlocked") >= thisLevelNumber - 1) {
            if(currentMoney >= goldTillUnlocked) {
              currentMoney -= goldTillUnlocked;
              PlayerPrefs.SetInt("gold", currentMoney);
              PlayerPrefs.SetInt("maxLevelUnlocked", thisLevelNumber);
              if(unlockedLevelImage != null) {
                unlockedLevelImage.SetActive(false);
              }
              levelIsUnlocked = true;
              Debug.Log("scene was unlocked");
            } else {
              // show alert saying you don't have enough gold?
              notEnoughGoldAlert.SetActive(true);
            }
          } else {
            //show alert saying the previous level must be unlocked
            unlockPreviousLevelAlert.SetActive(true);
          }
        }

    }
}
