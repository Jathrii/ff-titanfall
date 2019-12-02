using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    public Text weaponName;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
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

        if (selectedWeapon == 0)
        {
            weaponName.text = "Assault Rifle";
            GameObject.Find("Assault Rifle").GetComponent<Gun>().UpdateAmmoText();
        }
        else if (selectedWeapon == 1)
        {
            weaponName.text = "Shotgun";
            GameObject.Find("Shotgun").GetComponent<Gun>().UpdateAmmoText();
        }
        else if (selectedWeapon == 2)
        {
            weaponName.text = "Sniper Rifle";
            GameObject.Find("Sniper Rifle").GetComponent<Gun>().UpdateAmmoText();
        }

        else if (selectedWeapon == 3)
        {
            weaponName.text = "Grenade Launcher";
            // GameObject.Find("Sniper Rifle").GetComponent<Gun>().UpdateAmmoText();
        }

        else if (selectedWeapon == 4)
            weaponName.text = "RPG";

    }
}
