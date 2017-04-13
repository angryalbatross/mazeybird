using UnityEngine;
using System.Collections;


public class ManageScreens : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject springLevels;

    public void Start() {
      //unlock level 1 if we haven't unlocked anything yet
      int maxLevelUnlocked = PlayerPrefs.GetInt("maxLevelUnlocked");
      if(maxLevelUnlocked <= 0) {
        PlayerPrefs.SetInt("maxLevelUnlocked", 1);
      }

      //supposed to show he level screen when we are returning from
      int lastLevelLoaded = PlayerPrefs.GetInt("lastLevelLoaded");
      Debug.Log("lastLevelLoaded was = " + lastLevelLoaded);

      if (lastLevelLoaded == 0) {
        //show the main menu because we quit the game
        mainMenu.SetActive(true);
      } else {
        //show the level select screen
        springLevels.SetActive(true);
      }
    }
}
