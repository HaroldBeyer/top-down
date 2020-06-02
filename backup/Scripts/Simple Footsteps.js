#pragma strict
var AudioFile : AudioClip;

function Start () {

}

function Update () {

     if (Input.GetKeyDown (KeyCode.W))
    {
    audio.clip = AudioFile;
    audio.Play();
     
    }
    
         if (Input.GetKeyUp (KeyCode.W))
    {
    audio.clip = AudioFile;
    audio.Stop();
     
    }
     
}