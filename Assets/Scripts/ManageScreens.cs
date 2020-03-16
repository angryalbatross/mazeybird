using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManageScreens : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject springLevels;
    public GameObject lives;

    public void Start() {
      var livesText = lives.GetComponent<Text>();
      livesText.text = PlayerPrefs.GetInt("lives").ToString();

      //unlock level 1 if we haven't unlocked anything yet
      int maxLevelUnlocked = PlayerPrefs.GetInt("maxLevelUnlocked");
      if(maxLevelUnlocked <= 0) {
        PlayerPrefs.SetInt("maxLevelUnlocked", 1);
      }

      //The first time the user loads the game, give them 5 lives.
      int initialLoad = PlayerPrefs.GetInt("initialLoad");
      if(initialLoad == 0) {
        PlayerPrefs.SetInt("lives", 5);
        livesText.text = "5";
      }

      //give the player 5 lives if they have waited 24 hours since loosing their last live
      string lastLifeLostDate = PlayerPrefs.GetString("lastLifeLostDate");
  		if(lastLifeLostDate != "" && DateTime.UtcNow > Convert.ToDateTime(lastLifeLostDate).AddHours(22)) {
        PlayerPrefs.SetString("lastLifeLostDate", "");
        PlayerPrefs.SetInt("lives", 5);
        livesText.text = "5";
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
