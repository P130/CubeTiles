using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

    private bool paused = false;
    public GameObject pauseMenu;

	void Start ()
    {
		
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
                paused = true;
            }
            else
            {
                UnpauseGame();
                paused = false;
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
