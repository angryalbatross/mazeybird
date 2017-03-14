using UnityEngine;
using System.Collections;


public class ManageScreens : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject springLevels;

    public void Start() {
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
