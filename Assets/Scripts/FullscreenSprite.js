#pragma strict

var chosenCamera : Camera;

function Awake() {
	var spriteRenderer = GetComponent.<SpriteRenderer>();

  var cameraHeight = chosenCamera.orthographicSize * 2;
  var cameraSize = Vector2(chosenCamera.aspect * cameraHeight, cameraHeight);
  var spriteSize = spriteRenderer.sprite.bounds.size;

	var scale = transform.localScale;
	if(cameraSize.x >= cameraSize.y) {
		scale *= cameraSize.x / spriteSize.x;
	} else {
		scale *= cameraSize.y / spriteSize.y;
	}
	
	transform.localScale = scale;
}
