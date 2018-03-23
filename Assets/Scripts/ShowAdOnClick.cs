using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdOnClick : MonoBehaviour {

	public GameObject AdManager;
	public GameObject MainMenu;
	public GameObject AlreadyWatchedAdAlert	;

	public void ShowAdToUser()
	{
		string lastAdWatchedDate = PlayerPrefs.GetString("lastAdDate");
		if(lastAdWatchedDate == "" || DateTime.UtcNow >= Convert.ToDateTime(lastAdWatchedDate).AddHours(22)) {
			//then it has been 24 hours since we have watched an Ad
		#if UNITY_EDITOR
			var currentMaxLevel = PlayerPrefs.GetInt("maxLevelUnlocked");
			var currentMoney = PlayerPrefs.GetInt("gold");
			var currentLives = PlayerPrefs.GetInt("lives");
			PlayerPrefs.SetInt("gold", currentMoney + 10 + (2 * currentMaxLevel));
			PlayerPrefs.SetInt("lives", currentLives + 1);
			// set the last time that we watched an Ad
			PlayerPrefs.SetString("lastAdDate", DateTime.UtcNow.ToString());
			MainMenu.SetActive(true);
		#else
			AdManager.SendMessage("ShowRewardedAd", SendMessageOptions.DontRequireReceiver);
		#endif
		} else {
			//show an alert that the user has to wait 24 hours between watching Ad's
			AlreadyWatchedAdAlert.SetActive(true);
		}
	}
}
