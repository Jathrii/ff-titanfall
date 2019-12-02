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
}
