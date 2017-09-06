#pragma strict
var lives = 1;

function OnEnable () {
	  var initialLoad = PlayerPrefs.GetInt("initialLoad");
		if(initialLoad == 0) {
			//The first time the user loads the game, give them 5 lives.
			PlayerPrefs.SetInt("lives", 5);
		}
		lives = PlayerPrefs.GetInt("lives");
		GetComponent.<UI.Text>().text = lives.ToString();
}
