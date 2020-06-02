using System.Collections;
using UnityEngine;

public class PresentationScript : MonoBehaviour
{
    public GameObject mainMenu;

    private float timeToWait = 5f;
    private float done = 0.0f;

    // public Text img;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        // StartCoroutine(FadeOutRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EndAnimation()
    {
        mainMenu.SetActive(true);
        Destroy(gameObject, 0f);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        EndAnimation();
    }
    // private IEnumerator FadeOutRoutine()
    // {
    //     print("Olha, começou");
    //     // Text text = GetComponent<Text>();
    //     // print(text);
    //     // Color originalColor = text.color;
    //     // for (float t = 0.01f; t < timeToWait; t += Time.deltaTime)
    //     // {
    //     //     print(t);
    //     //     text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / timeToWait));
    //     //     yield return null;
    //     // }
    // }
}
