#pragma strict

var Weapon1: Sprite;
var Weapon2: Sprite;

var sprite : SpriteRenderer;

function Start ()
{
    sprite = GetComponent(SpriteRenderer);
}

function Update ()
{
    if(Input.GetKey(KeyCode.Alpha2))
    {
        sprite.sprite = Weapon1;
    }

    if(Input.GetKey(KeyCode.Alpha1))
    {
        sprite.sprite = Weapon2;
    }
}