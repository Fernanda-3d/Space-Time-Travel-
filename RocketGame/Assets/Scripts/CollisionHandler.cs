using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float levelLoadDelay = 2f;
   [SerializeField] AudioClip explodeSound;
   [SerializeField] AudioClip finishSound;

   AudioSource boostSound;

    /*Switch Statements are a Conditional like If/Else Statements - 
    allow us to compare a single variable(variables can change or "vary")
    to a series of constants - ex. things that don't change or have a "constant" value
    */

    void Start()
    {
        boostSound = GetComponent<AudioSource>();
    }
   void OnCollisionEnter(Collision other)
   {
       switch (other.gameObject.tag)
       {
           case "Start":
                Debug.Log("You start here");
                break;

            case "Finish":
                NextLevel();
                break;

            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                StartCrashSequence(); 
                break;           
       }
   }

    private void NextLevel()
    {       
        boostSound.PlayOneShot(finishSound);
        GetComponent<Movement>().enabled = false;
      Invoke ("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
   {
       boostSound.PlayOneShot(explodeSound);
       GetComponent<Movement>().enabled = false;
      Invoke ("ReloadLevel", levelLoadDelay); //we use Invoke to put a bit of a delay in the action happening
   }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // minha cena e a ativa - ex:0
        int nextSceneIndex = currentSceneIndex +1; // proxima cena e a minha cena +1 - ex: 1

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) // se minha proxima cena e a ultima cena do total de cenas
        {
            nextSceneIndex = 0; // ai eu volto para a primeira cena
        }
        SceneManager.LoadScene(nextSceneIndex); //sempre vai procurar pela proxima
    }

    void ReloadLevel()
   {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        // .buildIndex means that the number of the index is the one we're currently on
   }


}
