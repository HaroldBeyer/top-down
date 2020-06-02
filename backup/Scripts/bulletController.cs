using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "enemy")
        {
            rocketController.score++;
			rocketController.numberofasteroids--;
            Destroy(this.gameObject);
            Destroy(otherObject.gameObject);
        }
    }

    void OnBecameInvisible()
    {
     
        Destroy(this.gameObject);
    }




	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * 20f * Time.deltaTime);
	
	}
}
