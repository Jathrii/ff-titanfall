using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class switcher : MonoBehaviour
{bool mute;
      void Start () 
    {}
    public void GotoGameScene()
    {
        SceneManager.LoadScene("load");
    }
     public void ContGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
     public void SetLevel (float sliderValue)
    {
       
       AudioListener.volume = Mathf.Log10(sliderValue)*20 ;
    }
   
  public void GotoOptionScene()
    {
        SceneManager.LoadScene("options");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();

    }
}