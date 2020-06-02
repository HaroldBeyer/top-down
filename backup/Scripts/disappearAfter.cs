using UnityEngine;
using System.Collections;

public class disappearAfter : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        StartCoroutine(fadeOut());

	}

    IEnumerator fadeOut()
    {
		yield return new WaitForSeconds(3.0f);
        float opacity = 1f;

        while (opacity > 0f)
        {
           // Debug.Log(opacity);
            opacity = opacity - 0.1f;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,opacity);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

	

}
