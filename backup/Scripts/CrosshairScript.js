#pragma strict
	    
    var Crosshair : Texture2D;
    var CrosshairSizeX : int = 25; 
    var CrosshairSizeY : int = 25;
     
    function Start()
    {
        Screen.showCursor = false;
    }
     
    function OnGUI()
    {
        GUI.DrawTexture (Rect(Event.current.mousePosition.x-CrosshairSizeX/2, Event.current.mousePosition.y-CrosshairSizeY/2, CrosshairSizeX, CrosshairSizeY), Crosshair);
    }

