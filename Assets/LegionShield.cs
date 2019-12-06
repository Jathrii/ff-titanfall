using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegionShield : MonoBehaviour
{

    public GameObject legionShield;

    bool isShieldActivated;
    bool useDefensiveAbility;
    public Text cooldownText;

    // Start is called before the first frame update
    void Start()
    {
        isShieldActivated = false;
        useDefensiveAbility = true;
        cooldownText.text = "Gun Shield\nReady for use";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (useDefensiveAbility)
            {
                
                StartCoroutine(activateDefensiveAbility());
            }
        }
    }

    public IEnumerator activateDefensiveAbility(float countdownValue = 10)
    {
        float currCountdown = countdownValue;
        useDefensiveAbility = false;
        isShieldActivated = true;
        legionShield.SetActive(true);
        cooldownText.text = "Gun Shield\nActivated";

        while (currCountdown > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdown--;
        }

        legionShield.SetActive(false);
        isShieldActivated = false;
        StartCoroutine(defensiveAbilityCoolDown());
    }

    public IEnumerator defensiveAbilityCoolDown(float countdownValue = 15)
    {
        float currCountdownValue = countdownValue;

        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            cooldownText.text = "Defensive Cooldown: " + currCountdownValue;
        }

        cooldownText.text = "Gun Shield\nReady for use";

        useDefensiveAbility = true;
    }

    public bool isShieldActivate()
    {
        return isShieldActivated;
    }
}
