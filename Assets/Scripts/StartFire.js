#pragma strict

public var fireEffect : ParticleSystem;
public var player : GameObject;
private var touchingBlock : boolean = false;

function FixedUpdate ()
{
  if(touchingBlock){
    Debug.Log("SOMETHING TOUCHED ME");
  }
 }

function OnTriggerEnter(other : Collider) {
     if (other.tag == "Player") {
         touchingBlock = true;
     }
 }

function OnTriggerExit(other : Collider) {
     if (other.tag == "Player") {
         touchingBlock = false;
     }
 }
