using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids_inst : MonoBehaviour
{
   public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public int xPos;
    public int yPos;
    public int zPos;

    public int xPos2;
    public int yPos2;
    public int zPos2;

     public int xPos3;
    public int yPos3;
    public int zPos3; 

    

  

    public int asteroidCount;

    Vector3 temp;


    void Start()
    {

        StartCoroutine(AsteroidDrop());
        
    }
    IEnumerator AsteroidDrop()
    {
       
        while (asteroidCount < 10)
        {
            
            xPos = Random.Range(230, 750);
            yPos = Random.Range(-1, 150);
            zPos = Random.Range(-50, 110);
            

            xPos2 = Random.Range(250, 850);
            yPos2 = Random.Range(-2, 100);
            zPos2 = Random.Range(-40, 130);

            xPos3 = Random.Range(280, 700);
            yPos3 = Random.Range(0,80);
            zPos3 = Random.Range(-55, 115);

           GameObject asteroid_1 = Instantiate(asteroid1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
           GameObject asteroid_2 = Instantiate(asteroid2, new Vector3(xPos2, yPos2, zPos2), Quaternion.identity);
           GameObject asteroid_3 = Instantiate(asteroid3, new Vector3(xPos2, yPos2, zPos2), Quaternion.identity);

            
           asteroid1.transform.localScale = new Vector3 (Random.Range(0.2f, 1.0f), Random.Range(0.7f, 1.0f), Random.Range(0.5f, 1.0f));
           asteroid2.transform.localScale = new Vector3 (Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.7f, 1.3f));
           asteroid3.transform.localScale = new Vector3 (Random.Range(0.7f, 1.0f), Random.Range(0.3f, 0.7f), Random.Range(0.3f, 1.0f));

            // transform.localScale *= Random.Range(minScale, maxScale);

            /* temp = transform.localScale;
             temp.x *= Random.Range(1, 5);
             temp.y *= Random.Range(1, 5);
             temp.z *= Random.Range(1, 55);
             transform.localScale = temp;*/

            yield return new WaitForSeconds(0.01f);
            asteroidCount += 1;

           }
    }
            
}



