using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;

    private float startHealth;

    public Image healthBar;

    void Start()
    {
        startHealth = health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Pilot"))
        {
            if(GameObject.Find("PlayerPilot") != null)
                GameObject.Find("PlayerPilot").GetComponent<PlayerPilot>().increaseTitanMeter(10);
            else
                GameObject.Find("PlayerTitan").GetComponent<PlayerTitan>().increaseTitanMeter(10);
        }
        else if (gameObject.CompareTag("Titan"))
        {
            if (GameObject.Find("PlayerPilot") != null)
                GameObject.Find("PlayerPilot").GetComponent<PlayerPilot>().increaseTitanMeter(50);
            else
                GameObject.Find("PlayerTitan").GetComponent<PlayerTitan>().increaseTitanMeter(50);
        }
        Destroy(gameObject);
    }
}
