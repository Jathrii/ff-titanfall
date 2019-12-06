using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTitan : MonoBehaviour
{
    int healthPoints;
    int titanMeterPoints;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 400;
        titanMeterPoints = 0;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(healthPoints);
        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
        GameObject.Find("HUD").transform.Find("DashPoints").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Disembark Titan
            healthPoints = 0;

        if (Input.GetKeyDown(KeyCode.V))
        {
            if(titanMeterPoints >= 100)
            {
                StartCoroutine(enableAutoAim());
                titanMeterPoints = 0;
                GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
            }

        }


        if (healthPoints <= 0)
            onExitTitan();
    }

    void onExitTitan()
    {
        GameObject.Find("Players").transform.Find("PlayerPilot").position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject.Find("Players").transform.Find("PlayerPilot").gameObject.SetActive(true);
        healthPoints = 100;
        titanMeterPoints = 0;
        GameObject.Find("Players").transform.Find("PlayerPilot").GetComponent<PlayerPilot>().setTitanDeployed(false);
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(healthPoints);
        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
        GameObject.Find("Players").transform.Find("PlayerTitan").gameObject.SetActive(false);
    }

    public void increaseTitanMeter(int value)
    {
        titanMeterPoints += value;

        if (titanMeterPoints >= 100)
            titanMeterPoints = 100;

        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
    }

    public int getTitanMeter()
    {
        return titanMeterPoints;
    }

    public void setTitanMeter(int titanMeterPoints)
    {
        this.titanMeterPoints = titanMeterPoints;
        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
    }

    public void takeDamage(int damage)
    {
        healthPoints = healthPoints - damage;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(healthPoints);
    }


    public IEnumerator enableAutoAim(float countdownValue = 5)
    {
        float currCountdownValue = countdownValue;
        GameObject.Find("PlayerTitan").transform.Find("Titan").transform.Find("FirstPersonCharacter").Find("AutoAimTrigger").gameObject.SetActive(true);
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        GameObject.Find("PlayerTitan").transform.Find("Titan").transform.Find("FirstPersonCharacter").Find("AutoAimTrigger").gameObject.SetActive(false);
        resetCamera();
    }

    public void resetCamera()
    {
        GameObject.Find("PlayerTitan").transform.Find("Titan").transform.position = GameObject.Find("PlayerTitan").transform.position;
        GameObject.Find("PlayerTitan").transform.Find("Titan").transform.rotation = GameObject.Find("PlayerTitan").transform.rotation;
    }


}
