using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    bool canJump = true;
    public Vector3 startPos;
    public bool AllowJump = true;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(playerSpeed, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-playerSpeed, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, playerSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -playerSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            if (AllowJump)
            {
                canJump = false; // change to false so no air jumping
                //Add velocity to the rigidbody
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 5.0f, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;

        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            Respawn();

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Respawn")
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        //If the cube touches the respawn trigger, we turn
        // make it a kinematic RB, move it, then re-enable
        //rigidibody.
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        this.GetComponent<Rigidbody>().position = startPos;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
}
