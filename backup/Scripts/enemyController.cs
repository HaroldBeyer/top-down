using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine("changeDirection");

	}

    int direction = 0;
  

    IEnumerator changeDirection()
    {
        while (true)
        {
           

            direction = Random.Range(0, 5);

  

            yield return new WaitForSeconds(1f);
        }
        
       

    }



	
	// Update is called once per frame
	void Update () {
      

        //first find screen edge
        Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        //work out the margins

        //if the asteroid leaves the screen from the right, bring it in from the left
        if (transform.position.x > topRightCorner.x)
        {
            transform.position = new Vector3(-topRightCorner.x, transform.position.y);
        }

        //if the asteroid leaves the screen from the left, bring it in from the right
        if (transform.position.x < -topRightCorner.x)
        {
            transform.position = new Vector3(topRightCorner.x, transform.position.y);
        }

        //if the asteroid leaves the screen from the top, bring it in from the bottom
        if (transform.position.y > topRightCorner.y)
        {
            transform.position = new Vector3(transform.position.x, -topRightCorner.y);
        }

        //if the asteroid leaves the screen from the bottom, bring it in from the top
        if (transform.position.y < -topRightCorner.y)
        {
            transform.position = new Vector3(transform.position.x, topRightCorner.y);
        }


        //if the random direction is 0, go up
        if (direction == 0)
            transform.Translate(Vector3.up * 1f * Time.deltaTime);


        //if 1 go down
        if (direction == 1)
            transform.Translate(Vector3.down * 1f * Time.deltaTime);

        //if 2 go left
        if (direction == 2)
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
        

        //if 3 go right
        if (direction == 3)
            transform.Translate(Vector3.right * 1f * Time.deltaTime);


        //if 4 move towards player
        if (direction == 4)
            transform.position = Vector3.Lerp(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 1f * Time.deltaTime);
	

	}
}
