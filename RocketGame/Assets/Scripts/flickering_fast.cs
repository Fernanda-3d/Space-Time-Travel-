using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering_fast : MonoBehaviour
{    public bool isFlickering = false;
    public float timeDelay;


    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }

    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        timeDelay = Random.Range(0.05f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        timeDelay = Random.Range(0.05f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;

    }
}
