using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitanMeter : MonoBehaviour
{
    public Image ImgTitanMeterBar;

    public Text TxtTitanMeter;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    public void SetTitanMeter(int titanMeter)
    {
        if (titanMeter != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = titanMeter;

                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtTitanMeter.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));

            ImgTitanMeterBar.fillAmount = mCurrentPercent;
        }
    }

    public float currentPercent
    {
        get { return mCurrentPercent; }
    }

    public int currentValue
    {
        get { return mCurrentValue; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
