using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float force = 100f;
    [SerializeField] float rotateForce = 100f;
    [SerializeField] AudioClip mainEngine;
    AudioSource boostSound;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust(); // creating a method
        ProcessRotation();
    }


  private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           rb.AddRelativeForce(Vector3.up * force * Time.deltaTime); //Relative to rigidbody position/rotation
          if(!boostSound.isPlaying)
          {
              boostSound.PlayOneShot(mainEngine);
          }
          
        }
       else
       {
           boostSound.Stop();
       }
    }
    
    private void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateForce);
        }

        else if (Input.GetKey(KeyCode.D))
        {
           ApplyRotation(-rotateForce);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can rotate
                                  //for fix when the rocket colides with the obstacle 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation 
    }

}
