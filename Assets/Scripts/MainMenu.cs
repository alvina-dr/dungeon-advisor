using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public Toggle toggleElement;
    
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load the scene after 0 (mainMenu)
    }

    public void FullscreenToggle()
    {
        if (toggleElement.value)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            Debug.Log("is fullscreen");
        }
        else if (toggleElement.value == false)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Debug.Log("is windowed"); 
        }
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
