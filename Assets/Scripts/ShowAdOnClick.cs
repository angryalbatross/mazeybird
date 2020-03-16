using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAdOnClick : MonoBehaviour {

	public GameObject AdManager;
	public GameObject MainMenu;
	public GameObject WatchEntireAdAlert;
    public GameObject lives;

	public void ShowAdToUser()
	{
		var livesText = lives.GetComponent<Text>();
		#if UNITY_EDITOR
			var currentLives = PlayerPrefs.GetInt("lives");
			PlayerPrefs.SetInt("lives", currentLives + 1);
			livesText.text = (currentLives + 1).ToString();
			Debug.Log("You Watched an Advertisement");
			MainMenu.SetActive(true);
		#elif UNITY_WEBGL
			var currentLives = PlayerPrefs.GetInt("lives");
			PlayerPrefs.SetInt("lives", currentLives + 1);
			livesText.text = (currentLives + 1).ToString();
			Debug.Log("You Watched an Advertisement");
			MainMenu.SetActive(true);
		#else
			AdManager.SendMessage("ShowRewardedAd", SendMessageOptions.DontRequireReceiver);
		#endif
	}
}
