using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
public class AdManager : MonoBehaviour
{
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
        var currentMaxLevel = PlayerPrefs.GetInt("maxLevelUnlocked");
        var currentMoney = PlayerPrefs.GetInt("gold");
    		var currentLives = PlayerPrefs.GetInt("lives");
    		PlayerPrefs.SetInt("gold", currentMoney + 10 + (2 * currentMaxLevel));
    		PlayerPrefs.SetInt("lives", currentLives + 1);
        PlayerPrefs.SetString("lastAdDate", DateTime.UtcNow.ToString);
        break;
      case ShowResult.Skipped:
        Debug.Log("The ad was skipped before reaching the end.");
        break;
      case ShowResult.Failed:
        Debug.LogError("The ad failed to be shown.");
        break;
    }
  }
  #endif
}
