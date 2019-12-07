using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 4f;
    public float force = 700f;
    public float damage = 125f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
       // InvokeRepeating("DestroyExplosionEffect", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {

        GameObject GO = Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
           Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            if(nearbyObject.CompareTag("Titan") || nearbyObject.CompareTag("Pilot"))
            {
                Target target = nearbyObject.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }

        Destroy(GO, 5f);
        Destroy(gameObject);
    }

    public void DestroyExplosionEffect()
    {
        if(GameObject.Find("Explosion(Clone)") != null)
            Destroy(GameObject.Find("Explosion(Clone)"));
    }

    void OnCollisionEnter(Collision collision)
    {
        if(GameObject.Find("RPG") != null) {
            countdown = 0;
        }
    }

}
