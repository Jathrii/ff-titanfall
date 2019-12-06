using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPilot : MonoBehaviour
{

    int healthPoints = 100;
    int titanMeterPoints;
    bool isTitanDeployed;
    public GameObject titan;
    GameObject mainObjects;
    GameObject pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 100;
        titanMeterPoints = 0;
        isTitanDeployed = false;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(healthPoints);
        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
        GameObject.Find("Menus").transform.Find("PauseMenu").gameObject.SetActive(false);
        GameObject.Find("Menus").transform.Find("GameOver").gameObject.SetActive(false);
        GameObject.Find("HUD").transform.Find("DashPoints").gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V)) // This line is for testing (should be removed later).
            healthPoints = 0;

        if (healthPoints <= 0)
        {
            GameObject.Find("Menus").transform.Find("GameOver").gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;

                hidePaused();
            }
        }
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isTitanDeployed)
            {
                callTitan();
            }

            if (Input.GetKeyDown(KeyCode.E) && isTitanDeployed)
            {
                enterTitan();
            }
        }
    }

    public void increaseTitanMeter(int value)
    {
        titanMeterPoints += value;

        if (titanMeterPoints >= 100)
            titanMeterPoints = 100;

        GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
    }

    public void callTitan()
    {
        if (titanMeterPoints >= 100 && !isTitanDeployed)
        {
            titan.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z + 20);
            Instantiate(titan);
            GameObject.Find("Players").transform.Find("PlayerTitan").position = new Vector3(titan.transform.position.x, titan.transform.position.y, titan.transform.position.z);
            titanMeterPoints = 0;
            isTitanDeployed = true;

            GameObject.Find("TitanMeter").GetComponent<TitanMeter>().SetTitanMeter(titanMeterPoints);
        }
    }

    public void showPaused()
    {
        GameObject.Find("Menus").transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void hidePaused()
    {
        GameObject.Find("Menus").transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void enterTitan()
    {
        Vector3 titanPosition = titan.transform.position;
        Vector3 playerPosition = transform.position;
        Vector3 differenceVector = new Vector3(titanPosition.x - playerPosition.x, titanPosition.y - playerPosition.y, titanPosition.z - playerPosition.z);
        Debug.Log(differenceVector.z);

        if (differenceVector.x < 3 && differenceVector.z < 3)
        {

            GameObject.Find("Players").transform.Find("PlayerTitan").gameObject.SetActive(true);
            Destroy(GameObject.Find("Sphere(Clone)"));
            GameObject.Find("PlayerPilot").SetActive(false);
        }
    }

    public void setTitanDeployed(bool isTitanDeployed)
    {
        this.isTitanDeployed = isTitanDeployed;
    }

    public void takeDamage(int damage)
    {
       
        this.healthPoints = this.healthPoints - damage;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealth(this.healthPoints);
    }

}
