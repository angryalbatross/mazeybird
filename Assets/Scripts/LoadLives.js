#pragma strict
var lives = 0;

function OnEnable () {
		lives = PlayerPrefs.GetInt("lives");
		GetComponent.<UI.Text>().text = lives.ToString();
}
