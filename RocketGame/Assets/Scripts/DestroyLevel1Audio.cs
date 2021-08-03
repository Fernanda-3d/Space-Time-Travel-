using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevel1Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Destroy(GameObject.FindGameObjectWithTag("level1_music"));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
