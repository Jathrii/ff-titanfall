using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWeapons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        choosePrimary();
        chooseHeavy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void choosePrimary()
    {
        GameObject primary = GameObject.Find("WeaponHolder").transform.Find("Primary").gameObject;
        primary.SetActive(true);

        primary.transform.Find("Assault Rifle").gameObject.SetActive(false);
        primary.transform.Find("Shotgun").gameObject.SetActive(false);
        primary.transform.Find("Sniper Rifle").gameObject.SetActive(false);

        if(weapon_change.primaryWeapon == 0)
            primary.transform.Find("Assault Rifle").gameObject.SetActive(true);

        if (weapon_change.primaryWeapon == 1)
            primary.transform.Find("Shotgun").gameObject.SetActive(true);

        if (weapon_change.primaryWeapon == 2)
            primary.transform.Find("Sniper Rifle").gameObject.SetActive(true);
    }

    void chooseHeavy()
    {
        GameObject heavy = GameObject.Find("WeaponHolder").transform.Find("Heavy").gameObject;
        heavy.SetActive(true);

        heavy.transform.Find("GrenadeLauncher").gameObject.SetActive(false);
        heavy.transform.Find("RPG").gameObject.SetActive(false);

        if (weapon_change.heavyWeapon == 0)
            heavy.transform.Find("GrenadeLauncher").gameObject.SetActive(true);

        if (weapon_change.heavyWeapon == 1)
            heavy.transform.Find("RPG").gameObject.SetActive(true);

        heavy.SetActive(false);
    }
}
