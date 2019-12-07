using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class weapon_change : MonoBehaviour
{
    public static int primaryWeapon = 0;
    public static int heavyWeapon = 0;
    public Text primaryWeaponName;
    public Text heavyWeaponName;
    public GameObject change;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //SelectPrimary();
        //SelectHeavy();

    }

    // Update is called once per frame
    void Update()

    {

    }
    public void choosePrimary()
    {

        int previousSelectedWeapon = primaryWeapon;
        if (primaryWeapon >= 2)
            primaryWeapon = 0;
        else
            primaryWeapon++;

        SelectPrimary();

    }

    public void chooseHeavy()
    {
        int previousSelectedWeapon = primaryWeapon;
        if (heavyWeapon >= 1)
            heavyWeapon = 0;
        else
            heavyWeapon++;

        SelectHeavy();

    }

    void SelectPrimary()

    {

        if (primaryWeapon == 0)
            primaryWeaponName.text = "Assault Rifle";

        else if (primaryWeapon == 1)
            primaryWeaponName.text = "Shotgun";

        else if (primaryWeapon == 2)
            primaryWeaponName.text = "Sniper Rifle";

    }

    void SelectHeavy()

    {
        if (heavyWeapon == 0)
            heavyWeaponName.text = "Grenade Launcher";

        else if (heavyWeapon == 1)
            heavyWeaponName.text = "RPG";
    }
}
