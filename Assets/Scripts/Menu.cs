using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public static bool gameIsPaused;
    public GameObject Panel;



    void Start()
    {
        Panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();

        }


    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Debug.Log("PausedGame");

            Time.timeScale = 0f;
            Panel.SetActive(true);

        }

    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        SceneManager.LoadScene("Quit");
    }

    public void Resume()
    {
        Debug.Log("Resumed");
        Time.timeScale = 1.0f;
        Panel.SetActive(false);

    }

    public void MenuShow()
    {

    }
}
