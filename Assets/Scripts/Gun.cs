using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public bool isBurst = false;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    public Animator animator;

    public Text weapon_ammo;

    Target target;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
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

        if (currentAmmo <= 0 || ((Input.GetKeyDown(KeyCode.R)) && currentAmmo < maxAmmo))
        {
            StartCoroutine(Reload());
            return;
        }

        if (isBurst)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
                Shoot();
            }
        }

        else if (!isBurst)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
                Shoot();
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

        currentAmmo = maxAmmo;
        UpdateAmmoText();
        isReloading = false;
    }

    public void UpdateAmmoText()
    {
        weapon_ammo.text = currentAmmo + " / ∞";
    }

    void Shoot()
    {

        muzzleFlash.Play();

        currentAmmo--;

        UpdateAmmoText();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.CompareTag("Pilot"))
                target = hit.transform.parent.GetComponent<Target>();
            else if (hit.transform.CompareTag("Titan"))
                target = hit.transform.GetComponent<Target>();
            else
                return;

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
