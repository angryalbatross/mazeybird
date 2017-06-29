#pragma strict
var sprite1 : Sprite;
var sprite2 : Sprite;


function OnCollisionEnter2D(coll : Collision2D) {
	if (coll.gameObject.tag == "Player")
    {
			var currentSprite = GetComponent(SpriteRenderer).sprite;
			if (currentSprite == sprite1) {
				GetComponent(SpriteRenderer).sprite = sprite2;
			}	 else {
				GetComponent(SpriteRenderer).sprite = sprite1;
			}
    }
}
