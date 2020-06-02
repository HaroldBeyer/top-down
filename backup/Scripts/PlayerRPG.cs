using UnityEngine;
using System.Collections;

public class PlayerRPG : MonoBehaviour {

	public static int score;
	public int shield=100;
	public int ammo=50;
	int shotsfired;
	public int moves = 3;
	public GameObject PrimaryWeaponBullet;
	public GameObject SecondaryWeaponBullet;
	bool showGUI = true;
	float startTime;
	bool paused = false;
	float levelLenght = 50f;
	public AudioClip HurtSound;
	public AudioClip AmmoSound;
	public AudioClip HealthSound;
	bool gun = false;
	bool gun1 = true;
	
	public static int numberofasteroids = 100;
	
	// Use this for initialization
	void Start () {
		score = 0;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.LeftShift))
		{
			transform.Translate(Vector3.up * 2.1f * Input.GetAxis("Vertical") * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			paused = !paused;
		}
		if (paused == true) {
			Time.timeScale = 0f;
		} else { Time.timeScale = 1f;
		}
		
		/* //top right corner
		Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0f));
		
		if (transform.position.x > topRightCorner.x)
		{
			transform.position = new Vector3(-topRightCorner.x, transform.position.y);
		}
		
		
		if (transform.position.x < -topRightCorner.x)
		{
			transform.position = new Vector3(topRightCorner.x, transform.position.y);
		}
		
		
		if (transform.position.y > topRightCorner.y)
		{
			transform.position = new Vector3(transform.position.x, -topRightCorner.y);
		}
		
		
		if (transform.position.y < -topRightCorner.y)
		{
			transform.position = new Vector3(transform.position.x, topRightCorner.y);
		} */
		
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			gun1 = true;
		}
		if (gun1 == true) {
			
			if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo>0))
			{
				if (paused == false) {
					shotsfired++;
					ammo--;
					Instantiate(PrimaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter").transform.position, transform.rotation);
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			gun1 = !gun1;
			gun1 = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			gun = true;
		}
		if (gun == true) {
			
			if (Input.GetKeyDown(KeyCode.Mouse0) && (ammo>0))
			{
				if (paused == false) {
					shotsfired++;
					ammo--;
					Instantiate(SecondaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter2").transform.position, transform.rotation);
					Instantiate(SecondaryWeaponBullet, GameObject.FindGameObjectWithTag("shooter3").transform.position, transform.rotation);
				}
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			gun = !gun;
			gun = false;
		}

		
		float randomX = 0f;
		float randomY = 0f;
		
		
		
		if (paused == false) {
		//Debug.Log (numberofasteroids > 0);
		if ((shield > 0))
		{
			//mouse/touch input
			//-------------------------------
			
			/* Vector3 mousePos = Input.mousePosition;
			
			Vector3 mouseScreenPoint = Camera.main.ScreenToWorldPoint
				(mousePos);
			
			transform.LookAt(mouseScreenPoint, Vector3.forward);
			
			transform.eulerAngles = new Vector3
				(0, 0, -transform.eulerAngles.z); 
			
			
			/*
            if (Input.GetMouseButton(0))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(mouseScreenPoint.x,mouseScreenPoint.y), 1f * Time.deltaTime);
            }
*/
			
			//-----------------------------------------------------------------------
			
			/*
			if (Input.GetKeyDown(KeyCode.Space) && moves > 0)
			{
				randomX = Random.Range(-topRightCorner.x + 1, topRightCorner.x - 1);
				randomY = Random.Range(-topRightCorner.y + 1, topRightCorner.y - 1);
				transform.position = new Vector3(randomX, randomY);
				moves--;
			} */
			//------------------KEYBOARD CONTROL-----------------------
			transform.Translate(Vector3.up * 2f * Input.GetAxis("Vertical") * Time.deltaTime);
			transform.Rotate(Vector3.back * 60f * Input.GetAxis("Horizontal") * Time.deltaTime);
			//------------------END KEYBOARD CONTROL-------------------
		}
		else
			{
			showGUI = false;
		}
	}
	}
	
	
	void OnTriggerEnter2D(Collider2D otherObject)
	{
		if (otherObject.tag == "enemy")
		{
			shield -= 10;
			Destroy(otherObject.gameObject);
			audio.PlayOneShot(HurtSound, 2.7F);
			numberofasteroids--;
		}
		if (otherObject.tag == "shield")
		{
			shield = 100;
			audio.PlayOneShot(HealthSound, 7.7F);
			Destroy(otherObject.gameObject);
			
		}
		if (otherObject.tag == "ammo")
		{
			ammo = 50;
			audio.PlayOneShot(AmmoSound, 7.7F);
			Destroy(otherObject.gameObject);
		}
		
	}
	
	
	void OnGUI()
	{
		//if (((Time.time - startTime) > levelLenght))
		{
			//GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 34.5f), 200, 25), "DAY SURVIVED");
			//GUI.Button(new Rect(((Screen.width / 2) - 50f), ((Screen.height / 2) - 12.5f), 100, 25),"RETRY");
		}
		
		if (showGUI)
		{
			GUI.color = Color.white;
			GUI.Label(new Rect(100, 7, 100, 25), "Ammo:" + ammo);
			GUI.Label(new Rect(200, 7, 100, 25), "Shots Fired:" + shotsfired);
			GUI.Label(new Rect(10, 7, 100, 25), "Health:" + shield);
			//GUI.Label (new Rect (10, 55, 150, 50), "Time Left: " + (levelLenght-(Time.time - startTime)));
			GUI.Label (new Rect (320, 7, 150, 50), "Time Survived: " + (Time.time - startTime));
		}
		else
		{
			//Game ENDED
			if (shield ==0)
			{
				GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 12.5f), 250, 25), "YOU DIED");
				if (Time.timeScale == 1.0F)
					Time.timeScale = 0.1F;
				ammo = 0;
			}

		/*	else
			{
				GUI.Label(new Rect(((Screen.width / 2) - 48f), ((Screen.height / 2) - 34.5f), 200, 25), "DAY SURVIVED");
				if (GUI.Button(new Rect(((Screen.width / 2) - 50f), ((Screen.height / 2) - 12.5f), 100, 25),"CONTINUE"))
				{
					int currentLevel = Application.loadedLevel;
					Debug.Log(currentLevel);
					if (currentLevel < Application.levelCount-1)
					{
						Application.LoadLevel(currentLevel + 1);
					}
					else
					{
						Application.LoadLevel(0);		
					}
				}
			} */
			
		}
	}
	
}