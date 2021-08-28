using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArrow : MonoBehaviour
{
     [SerializeField] AudioClip collectSound;
     [SerializeField] AudioSource arrowSound;
    
    
    void OnTriggerEnter(Collider other) 
    {
         if(other.gameObject.tag == "Player")
         {
             arrowSound.PlayOneShot(collectSound);
             Destroy(gameObject);
     }
}
}
