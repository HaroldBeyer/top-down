    var visible;
    var windowRect;
    var PauseTexture : Texture2D;
    
    function Start()
    
    {
    	visible = false;
    	windowRect = Rect( 0,0, 1300,900);
    }
    
   		 function OnTriggerEnter(other : Collider) {
    	 OnGUI();
    
 	}
   		function OnGUI()
    {
    
   		if( visible )
   	{
    	GUI.Box( windowRect, PauseTexture );
    }
    
   	}
    	function Update()
    {
    	if( Input.GetKeyDown( KeyCode.P ) )
    {
    	visible = !visible;
    	
    }
   }
     