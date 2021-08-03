using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_level2audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Destroy(GameObject.FindGameObjectWithTag("level2_music"));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
