using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserCore : MonoBehaviour
{

    Queue<GameObject> laserBeamsQueue;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject laserCore;
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
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        int titanMeterPoints = GameObject.Find("PlayerTitan").GetComponent<PlayerTitan>().getTitanMeter();

        if (Input.GetKeyDown(KeyCode.V) && titanMeterPoints >= 100)
        {
            Shoot(10);
            StartCoroutine(ShootLaserCore());
        }

    }

    IEnumerator ShootLaserCore(float countdownValue = 3)
    {

        float currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        while (laserBeamsQueue.ToArray().Length > 0)
        {
            Destroy(laserBeamsQueue.Dequeue());
        }

        GameObject.Find("PlayerTitan").GetComponent<PlayerTitan>().setTitanMeter(0);

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
            
        }
    }

    void ThrowGrenade(int throwForce)
    {

        GameObject grenade = Instantiate(laserCore, transform.position, transform.rotation);

        laserBeamsQueue.Enqueue(grenade);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
