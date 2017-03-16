using UnityEngine;
using System.Collections;


public class DeletePlayerPrefs : MonoBehaviour {

    public void shouldWeDeletePlayerPrefs(bool deletePlayerPrefs) {
      if(deletePlayerPrefs) {
        PlayerPrefs.DeleteAll();
      }
    }
}
