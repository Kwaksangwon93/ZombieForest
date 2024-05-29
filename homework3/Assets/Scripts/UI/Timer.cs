using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float seconds;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        seconds -= Time.deltaTime;

        if (seconds <= 0 )
        {
            seconds = 0;
        }

        if (seconds == 0)
        {
            SceneManager.LoadScene("StartScene");
        }

        text.text = string.Format("{0:N2}", seconds);
    }
}
