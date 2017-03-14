using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
        PlayerPrefs.SetInt("lastLevelLoaded", 0);
        PlayerPrefs.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

}
