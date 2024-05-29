using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(loadMainScene());
    }

    IEnumerator loadMainScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
        StopCoroutine(loadMainScene());
    }
}