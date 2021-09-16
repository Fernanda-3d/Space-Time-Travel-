using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.0f;
    public AudioClip play;
    public AudioClip quit;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PressPlay()
    {
    audioSource.PlayOneShot(play);
    Invoke ("LoadNextLevel", levelLoadDelay);
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
    
     public void PressQuit()
    {
    audioSource.PlayOneShot(quit);
    Invoke ("QuitGame", levelLoadDelay);
    }
    private void QuitGame()
    {
    //Application.Quit();
    SceneManager.LoadScene("Intro");
    }
}
