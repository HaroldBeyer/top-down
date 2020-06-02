using UnityEngine;
using System.Collections;

public class enemygenerator : MonoBehaviour {

    public GameObject enemy;
    public GameObject shield;
    public GameObject ammo;
    public int maxEnemies;
    int enemies=0;

    void Start()
    {
         
		rocketController.numberofasteroids = maxEnemies;
		StartCoroutine ("countDown");
    }
	IEnumerator countDown()
	{
		yield return new WaitForSeconds (5f);
		StartCoroutine("generateEnemies");
		StartCoroutine("generatePowerups");

	}
    IEnumerator generateEnemies()
    {
        while(enemies < maxEnemies) {
            float randomX = Random.Range(9f,9f); //-9 , 9f
            float randomY = Random.Range(9f,9f);

            Vector3 position = new Vector3(randomX,randomY,0f);
            Instantiate (enemy, position,Quaternion.identity);
            enemies++;
            yield return new WaitForSeconds(1f);
        }

    }

    IEnumerator generatePowerups()
    {
        while (true)
        {
            float randomX = Random.Range(-3f, 3f); //4
            float randomY = Random.Range(-3f, 3f); //4

            int shieldorammo = Random.Range(0, 2);

            
            Vector3 position = new Vector3(randomX, randomY, 0f);

            if (shieldorammo == 1)
            {
                Instantiate(ammo, position, Quaternion.identity);
            }
            else
            {
                Instantiate(shield, position, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }


    /*
    IEnumerator generateEnemies()
    {
        while (true)
        {
           // Debug.Log(enemies);
            enemies = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (enemies <= maxEnemies)
            {
                int direction = Random.Range(0, 4);

                if (direction == 0)
                    Instantiate(enemy, new Vector3(0, 4, 0), Quaternion.identity);


                if (direction == 1)
                    Instantiate(enemy, new Vector3(0, -4, 0), Quaternion.identity);

                if (direction == 2)
                    Instantiate(enemy, new Vector3(4, 0, 0), Quaternion.identity);

                if (direction == 3)
                    Instantiate(enemy, new Vector3(-4, 0, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
     }*/

    
}
