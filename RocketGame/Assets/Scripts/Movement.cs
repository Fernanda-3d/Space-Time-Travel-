using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float force = 100f;
    [SerializeField] float rotateForce = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainParticle;
   [SerializeField] ParticleSystem AParticle;
   [SerializeField] ParticleSystem DParticle;
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


  private void ProcessThrust() //principal thing 1
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }
    }

     private void ProcessRotation() // principal thing 2
    {
         if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else //how to stop the particles
        {
            StopRotating();
        }
    }

   // ---------- start explanation what is in principal things 1 and 2 --------------
    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * force * Time.deltaTime); //Relative to rigidbody position/rotation
        if (!boostSound.isPlaying)
        {
            boostSound.PlayOneShot(mainEngine);
        }

        if (!mainParticle.isPlaying)
        {
            mainParticle.Play();
        }
    }
     private void StopThrusting()
    {
        boostSound.Stop();
        mainParticle.Stop();
    }

     
    private void RotateRight()
    {
        ApplyRotation(-rotateForce);
        if (!DParticle.isPlaying)
        {
            DParticle.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotateForce);
        if (!AParticle.isPlaying)
        {
            AParticle.Play();
        }
    }
      private void StopRotating()
    {
        AParticle.Stop();
        DParticle.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can rotate
                                  //for fix when the rocket colides with the obstacle 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation 
    }

}
