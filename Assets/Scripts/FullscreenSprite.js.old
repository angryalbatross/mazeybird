#pragma strict

var chosenCamera : Camera;

function Awake() {
	var spriteRenderer = GetComponent.<SpriteRenderer>();

  var cameraHeight = chosenCamera.orthographicSize * 2;
  var cameraSize = Vector2(chosenCamera.aspect * cameraHeight, cameraHeight);
  var spriteSize = spriteRenderer.sprite.bounds.size;

	var scale = transform.localScale;
	Debug.Log(scale);
		Debug.Log(cameraSize.x);
		Debug.Log(cameraSize.y);

			Debug.Log(spriteSize.x);
			Debug.Log(spriteSize.y);
	if(cameraSize.x >= cameraSize.y) {
		scale *= cameraSize.x / spriteSize.x;
	} else {
		scale *= cameraSize.y / spriteSize.y;
	}
	Debug.Log(scale);

	transform.localScale = scale;
}
