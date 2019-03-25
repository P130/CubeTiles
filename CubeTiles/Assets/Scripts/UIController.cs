using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private Scene currentScene;
    private int buildIndex;

    public GameObject completedLevelMenu;
    public Text score;
    public Text endScore;

    public Text highscore;

    private int scoreCounter = 0;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;
    }

   

    public void CompletedLevel()
    {
        completedLevelMenu.SetActive(true); //when player reaches the goal, this menu shows up

        endScore.text = "You finished the level with " + scoreCounter.ToString() + " moves"; //show the score

        if (buildIndex == 1) //we check in which scene we are and we save the score if it is lower than the old one 
        {
            if (PlayerPrefs.GetFloat("Lvl1Highscore") == 0)
                PlayerPrefs.SetFloat("Lvl1Highscore", 2000);
            if (PlayerPrefs.GetFloat("Lvl1Highscore") > scoreCounter)
            {
                PlayerPrefs.SetFloat("Lvl1Highscore", scoreCounter);
                highscore.text = "Your new highscore is: " + scoreCounter;
            }
            else
            {
                highscore.text = "Your highscore is: " + PlayerPrefs.GetFloat("Lvl1Highscore");
            }
        }
        else if (buildIndex == 2)
        {
            if (PlayerPrefs.GetFloat("Lvl2Highscore") == 0)
                PlayerPrefs.SetFloat("Lvl2Highscore", 2000);
            if (PlayerPrefs.GetFloat("Lvl2Highscore") > scoreCounter)
            {
                PlayerPrefs.SetFloat("Lvl2Highscore", scoreCounter);
                highscore.text = "Your new highscore is: " + scoreCounter;
            }
            else
            {
                highscore.text = "Your highscore is: " + PlayerPrefs.GetFloat("Lvl2Highscore");
            }
        }
        else if (buildIndex == 3)
        {
            if(PlayerPrefs.GetFloat("Lvl3Highscore") == 0)
                PlayerPrefs.SetFloat("Lvl3Highscore", 2000);
            if (PlayerPrefs.GetFloat("Lvl3Highscore") > scoreCounter)
            {
                PlayerPrefs.SetFloat("Lvl3Highscore", scoreCounter);
                highscore.text = "Your new highscore is: " + scoreCounter;
            }
            else
            {
                highscore.text = "Your highscore is: " + PlayerPrefs.GetFloat("Lvl3Highscore");
            }
        }

    }

    public void IncreaseScore(int added) //it is called each time a move is made
    {
        scoreCounter += added;
        score.text = scoreCounter.ToString();
    }



}
