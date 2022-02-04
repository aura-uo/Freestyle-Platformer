using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    void Update()
    {
        if ((WinPanel.getActive() || LosePanel.getActive()) && Input.GetAxis("Fire2") == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
