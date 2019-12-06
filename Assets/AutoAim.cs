using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public GameObject titan;
    public int lookSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pilot") || other.CompareTag("Titan"))
        {
           //Vector3 direction = other.transform.position - titan.transform.position;
           //Quaternion targetRotation = Quaternion.LookRotation(direction);
           //Quaternion lookAt = Quaternion.RotateTowards(titan.transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
            // var point = other.gameObject.transform.position;
            // point.y = 0;
            // point.z = 0;
            titan.transform.LookAt(other.transform.position);
            //titan.transform.rotation = lookAt;
        }

        StartCoroutine(resetCamera());

    }


    public void returnCamera()
    {
        titan.transform.position = GameObject.Find("PlayerTitan").transform.position;
        titan.transform.rotation = GameObject.Find("PlayerTitan").transform.rotation;
    }

    public IEnumerator resetCamera(float countdownValue = 1.5f)
    {
        float currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        returnCamera();

    }
}
