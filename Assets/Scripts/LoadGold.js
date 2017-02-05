#pragma strict
var gold = 1;

function OnEnable () {
		gold = PlayerPrefs.GetInt("gold");
		GetComponent.<UI.Text>().text = gold.ToString();
}
