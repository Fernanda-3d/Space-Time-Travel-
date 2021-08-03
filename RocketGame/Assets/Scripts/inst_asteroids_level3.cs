using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inst_asteroids_level3 : MonoBehaviour
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
       
        while (asteroidCount < 50)
        {
            
            xPos = Random.Range(-136, 1030);
            yPos = Random.Range(400, 520);
            zPos = Random.Range(-15, 20);
            

            xPos2 = Random.Range(-120, 1000);
            yPos2 = Random.Range(480, 500);
            zPos2 = Random.Range(-10, 13);

            xPos3 = Random.Range(-130, 1015);
            yPos3 = Random.Range(415, 510);
            zPos3 = Random.Range(-5, 15);

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
