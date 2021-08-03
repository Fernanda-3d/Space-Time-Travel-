using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyaudio_level3 : MonoBehaviour
{
     // Start is called before the first frame update
    void Start()
    {
      Destroy(GameObject.FindGameObjectWithTag("level3_music"));
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
