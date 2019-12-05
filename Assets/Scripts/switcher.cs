using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class switcher : MonoBehaviour
{bool mute;
      void Start () 
    {}
    public void GotoGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("load");
    }
     public void ContGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
     public void SetLevel (float sliderValue)
    {
        Time.timeScale = 1;
        AudioListener.volume = Mathf.Log10(sliderValue)*20 ;
    }
   
  public void GotoOptionScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("options");
    }

    public void GotoMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu 3D");
    }

    public void Quit()
    {
        Application.Quit();

    }
}