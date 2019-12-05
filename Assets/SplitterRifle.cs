using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitterRifle : MonoBehaviour
{

    Queue<GameObject> laserBeamsQueue;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public bool isBurst = false;

    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public GameObject laserBeam;
    // public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    public Animator animator;

    public Text weapon_ammo;

    // Start is called before the first frame update
    void Start()
    {
        laserBeamsQueue = new Queue<GameObject>();
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
        {
            return;
        }

        if (isBurst)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);

                while(laserBeamsQueue.ToArray().Length > 0)
                {
                    Destroy(laserBeamsQueue.Dequeue());
                }

                Shoot(30);
            }
        }

        else if (!isBurst)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
                Shoot(90);
            }
        }

    }

    IEnumerator Reload()
    {

        isReloading = true;
        Debug.Log("Reloading..");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);

        UpdateAmmoText();
        isReloading = false;
    }

    public void UpdateAmmoText()
    {
        weapon_ammo.text = "∞ / ∞";
    }

    void Shoot(int throwForce)
    {

        ThrowGrenade(throwForce);

        UpdateAmmoText();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    void ThrowGrenade(int throwForce)
    {

        Vector3 laserBeamTransformation = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        GameObject grenade = Instantiate(laserBeam, laserBeamTransformation, transform.rotation);

        laserBeamsQueue.Enqueue(grenade);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

        laserBeamTransformation = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        grenade = Instantiate(laserBeam, laserBeamTransformation, transform.rotation);

        laserBeamsQueue.Enqueue(grenade);

        rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

        laserBeamTransformation = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        grenade = Instantiate(laserBeam, laserBeamTransformation, transform.rotation);

        laserBeamsQueue.Enqueue(grenade);

        rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
