#pragma strict

var target : Transform;
var offset  = Vector3 (0, 0, -11);

function LateUpdate () {
    transform.position =  target.position + offset;
}
 