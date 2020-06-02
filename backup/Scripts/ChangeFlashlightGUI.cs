using UnityEngine;
using System.Collections;

public class ChangeFlashlightGUI : MonoBehaviour {

	public Sprite flashlighton; // Drag your first sprite here
	public Sprite flashlightoff; // Drag your second sprite here
	
	private SpriteRenderer spriteRenderer; 
	
		void Start ()
		{
			spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
			if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = flashlighton; // set the sprite to sprite1
		}
		
		void Update ()
		{
		if (Input.GetKeyDown (KeyCode.F)) // If the space bar is pushed down
			{
				ChangeTheDamnSprite (); // call method to change sprite
			}
		}
		
		void ChangeTheDamnSprite ()
		{
		if (spriteRenderer.sprite == flashlighton) // if the spriteRenderer sprite = sprite1 then change to sprite2
			{
			spriteRenderer.sprite = flashlightoff;
			}
			else
			{
			spriteRenderer.sprite = flashlighton; // otherwise change it back to sprite1
			}
		}
}