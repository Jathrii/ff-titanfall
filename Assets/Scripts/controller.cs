using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public Slider mSlider;
    public AudioSource gameAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        /*float x=Mathf.Pow(10,AudioListener.volume)/20;
   Debug.Log (x);
      // mSlider.value=x ;*/
    }

    // Update is called once per frame
    void Update()
    {
      /*  float x=Mathf.Pow(10,AudioListener.volume);
   Debug.Log (x);
        //  mSlider.value=x ;
        */
        gameAudioSource.volume = mSlider.value;
    }
}
