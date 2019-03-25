using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject musicObject;
    AudioSource myAudioSource;

    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public GameObject instructionsHolder;

    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;
    public int[] screenWidths;
    int activeScreenResIndex; //to keep track which resolution is selected

    private void Start()
    {
        myAudioSource = musicObject.GetComponent<AudioSource>();
        activeScreenResIndex = PlayerPrefs.GetInt("screenResIndex"); //using the PlayerPrefs we load the settings that player saved from previous time
        bool isFullScreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;
        myAudioSource.volume = PlayerPrefs.GetFloat("musicvolume");
        volumeSliders[1].value = myAudioSource.volume;

        for (int i=0;i<resolutionToggles.Length;i++) 
        {
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }

        fullscreenToggle.isOn = isFullScreen;
        
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsMenu() //according to which button is pressed in main menu, ui components appear and dissapear
    {
        mainMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);

    }

    public void ShowInstructions()
    {
        mainMenuHolder.SetActive(false);
        instructionsHolder.SetActive(true);
    }

    public void MainMenu()
    {
        mainMenuHolder.SetActive(true); 
        if(optionsMenuHolder.activeSelf)
            optionsMenuHolder.SetActive(false);
        if (instructionsHolder.activeSelf)
            instructionsHolder.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetScreenResolution(int i) //is executed each time a resolution is checked
    {
        if(resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i],(int)(screenWidths[i] / aspectRatio), false); //set the desired resolution
            PlayerPrefs.SetInt("screenResIndex", activeScreenResIndex);  //save the resolution
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullScreen)
    {
        for(int i = 0; i<resolutionToggles.Length;i++)
        {
            resolutionToggles[i].interactable = !isFullScreen; //disable the other options if fullscreen is selected
        }

        if(isFullScreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1]; 
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullScreen) ? 1 : 0));  
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        myAudioSource.volume = value;
        PlayerPrefs.SetFloat("musicvolume", value); //save volume
        PlayerPrefs.Save();
    }



}
