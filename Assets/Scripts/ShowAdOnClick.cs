using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdOnClick : MonoBehaviour {

	public GameObject AdManager;
	public GameObject MainMenu;
	public GameObject WatchEntireAdAlert	;

	public void ShowAdToUser()
	{
		#if UNITY_EDITOR
			var currentLives = PlayerPrefs.GetInt("lives");
			PlayerPrefs.SetInt("lives", currentLives + 1);
			Debug.Log("You Watched an Advertisement");
			MainMenu.SetActive(true);
		#else
			AdManager.SendMessage("ShowRewardedAd", SendMessageOptions.DontRequireReceiver);
		#endif
	}
}
