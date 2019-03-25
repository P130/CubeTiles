using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelButtons : MonoBehaviour {

    private Scene currentScene;
    private int buildIndex;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
    }

    public void LoadNewLevel()
    {
        switch (buildIndex)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(3);
                break;
            case 3:
                SceneManager.LoadScene(0);
                break;
        }
    }
	
	public void TryAgain()
    {
        switch (buildIndex)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
