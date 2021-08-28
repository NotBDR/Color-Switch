using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool ispaused=false;
    public GameObject PauseMenuUi;
    public GameObject pausedrest;
    public GameObject optionsrest;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown(KeyCode.P)) 
        { if (ispaused) { resume(); }
            else { pause(); }
        }
    }
    public void backtohome() { UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); }
    public void resume() { PauseMenuUi.SetActive(false); Time.timeScale = 1f; ispaused = false;  }
    void pause() { PauseMenuUi.SetActive(true); Time.timeScale = 0f; ispaused = true; }

    public void options() { pausedrest.SetActive(false); optionsrest.SetActive(true); }

    public void optionsback() { pausedrest.SetActive(true); optionsrest.SetActive(false); }
}
