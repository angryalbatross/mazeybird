using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour {

    // public GameObject notEnoughGoldAlert;
    // public GameObject unlockPreviousLevelAlert;
    // public GameObject unlockedLevelImage;
    public GameObject watchAdOrWaitAlert;
    //public GameObject gold;
    // public int goldTillUnlocked = 0;
    // public int thisLevelNumber = 0;
    // public bool levelIsUnlocked = false;
    // private int maxLevelUnlocked = 0;
    private int currentLives = 0;

    public void Start () {
    }

    public void LoadByIndex(int sceneIndex)
    {
          currentLives = PlayerPrefs.GetInt("lives");
          if(sceneIndex == 0 || currentLives > 0){
            SceneManager.LoadScene (sceneIndex);
          } else {
            //show alert to the user
            watchAdOrWaitAlert.SetActive(true);
          }

    }
}
