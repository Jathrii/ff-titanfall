using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
 
    public int selectedWeapon =0;

    // Start is called before the first frame update
    void Start()
    {
        
      
       selectedWeapon= weapon_change.n;
        Debug.Log(weapon_change.n);
        SelectWeapon();
    }

    // Update is called
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    
    void SelectWeapon()
    {
        int i = 0;

        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }

        if (GameObject.Find("Assault Rifle") != null)
            GameObject.Find("Assault Rifle").GetComponent<Gun>().UpdateAmmoText();

        else if (GameObject.Find("Shotgun") != null)
            GameObject.Find("Shotgun").GetComponent<Gun>().UpdateAmmoText();

        else if (GameObject.Find("Sniper Rifle") != null)
            GameObject.Find("Sniper Rifle").GetComponent<Gun>().UpdateAmmoText();

        else
            GameObject.Find("Weapon Ammo").GetComponent<Text>().text = "∞ / ∞";

    }
}
