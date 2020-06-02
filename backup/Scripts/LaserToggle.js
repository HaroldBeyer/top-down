#pragma strict

function Start () 
{
	this.renderer.enabled = false;
}

function Update () 
{
	if(Input.GetKeyDown("g"))
	{
		if(this.renderer.enabled == false)
		{
			this.renderer.enabled = true;
		}
		
		else
		{
			this.renderer.enabled = false;
		}
	}
}