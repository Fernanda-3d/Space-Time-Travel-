using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float levelLoadDelay = 2f;
   [SerializeField] AudioClip explodeSound;
   [SerializeField] AudioClip finishSound;
   [SerializeField] ParticleSystem explodeParticle;
   [SerializeField] ParticleSystem finishParticle;
       AudioSource boostSound;
   bool isTransitioning = false; //means if we are transitioning don't do stuff
   bool collisionDisabled = false; // we have collision on and them we will turn off by choice
   

    /*Switch Statements are a Conditional like If/Else Statements - 
    allow us to compare a single variable(variables can change or "vary")
    to a series of constants - ex. things that don't change or have a "constant" value
    */

    void Start()
    {
        boostSound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        RespondToDebugKeys();
    }
       void OnCollisionEnter(Collision other)
   {
       if (isTransitioning || collisionDisabled ) //means if is true ----- || this means or
       {
           return; //means don't go any further, then we won't be able to enter in the switch state
       }
 
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
        isTransitioning = true;
        boostSound.PlayOneShot(finishSound);
        finishParticle.Play();
        GetComponent<Movement>().enabled = false;
      Invoke ("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
   {
       isTransitioning = true;
       boostSound.PlayOneShot(explodeSound);
       explodeParticle.Play();
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

    void RespondToDebugKeys()
   {
        if (Input.GetKeyDown(KeyCode.L))
        {
          LoadNextLevel();
        }

         else if (Input.GetKeyDown(KeyCode.C))
        {
          collisionDisabled = !collisionDisabled; // this will toggle collision (if is false will flip to true and vice versa)
          // TOGGLE MEANING: switch from one effect, feature, or state to another by using a toggle
          //a key or command that is operated the same way but with opposite effect on successive occasions.
        }

   }



}
