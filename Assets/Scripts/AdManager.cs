using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
public class AdManager : MonoBehaviour
{
  public GameObject MainMenu;
  public GameObject WatchEntireAdAlert;
  #if UNITY_ADS
  public void ShowRewardedAd()
  {
    if (Advertisement.IsReady("rewardedVideo"))
    {
      var options = new ShowOptions { resultCallback = HandleShowResult };
      Advertisement.Show("rewardedVideo", options);
    }
  }

  private void HandleShowResult(ShowResult result)
  {
    switch (result)
    {
      case ShowResult.Finished:
        Debug.Log("The ad was successfully shown.");
        //
        // YOUR CODE TO REWARD THE GAMER
        // Give coins etc.
    		var currentLives = PlayerPrefs.GetInt("lives");
    		PlayerPrefs.SetInt("lives", currentLives + 1);
        MainMenu.SetActive(true);
        break;
      case ShowResult.Skipped:
        Debug.Log("The ad was skipped before reaching the end.");
        // MainMenu.SetActive(true);
        WatchEntireAdAlert.SetActive(true);
        break;
      case ShowResult.Failed:
        Debug.LogError("The ad failed to be shown.");
        MainMenu.SetActive(true);
        break;
    }
  }
  #endif
}
