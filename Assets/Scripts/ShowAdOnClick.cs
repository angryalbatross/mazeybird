using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdOnClick : MonoBehaviour {

	public GameObject AdManager;
	public GameObject MainMenu;

	public void ShowAdToUser()
	{
#if UNITY_EDITOR
		var currentMaxLevel = PlayerPrefs.GetInt("maxLevelUnlocked");
		var currentMoney = PlayerPrefs.GetInt("gold");
		PlayerPrefs.SetInt("gold", currentMoney + 10 + (2 * currentMaxLevel));
		MainMenu.SetActive(true);
#else
		AdManager.SendMessage("ShowRewardedAd", SendMessageOptions.DontRequireReceiver);
#endif
	}
}
