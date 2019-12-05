using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class weapon_change : MonoBehaviour
{
     public int selectedWeapon = 0;
    public Text weaponName;
     public static int n;
    public GameObject change;
    // Start is called before the first frame update
    void Start()
    { DontDestroyOnLoad(this.gameObject);
      SelectWeapon();
     
    }

    // Update is called once per frame
    void Update()
    
    {
        
    }
    public void choose(){

          int previousSelectedWeapon = selectedWeapon;
           if (selectedWeapon >= 4)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
           
        }

    }
     void SelectWeapon()
    
    {
        

        if (selectedWeapon == 0)
        {
            weaponName.text = "Assault Rifle";
            n= 0;
           
        }
        else if (selectedWeapon == 1)
        {
            weaponName.text = "Shotgun";
            n= 1;
           
        }
        else if (selectedWeapon == 2)
        {
            weaponName.text = "Sniper Rifle";
           n= 2;
        }

        else if (selectedWeapon == 3)
        {
            weaponName.text = "Grenade Launcher";
            n=3;
        }

        else if (selectedWeapon == 4){
            weaponName.text = "RPG";
            n=4;
        }
    }
}
