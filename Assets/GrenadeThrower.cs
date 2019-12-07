using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public New_Weapon_Recoil_Script recoil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("Explosion(Clone)") != null)
                Destroy(GameObject.Find("Explosion(Clone)"));

            recoil.Fire();
            ThrowGrenade();
        }   
    }

    void ThrowGrenade()
    {
        GameObject grenade;

        if (transform.name.Equals("RPG"))
        {
            Vector3 grenadeTransformation = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            grenade = Instantiate(grenadePrefab, grenadeTransformation, Quaternion.Euler(90,0,0));
        }
        else
            grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        if(transform.name.Equals("RPG"))
            rb.AddForce(transform.right * throwForce, ForceMode.VelocityChange);
        else
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    
    }
}
