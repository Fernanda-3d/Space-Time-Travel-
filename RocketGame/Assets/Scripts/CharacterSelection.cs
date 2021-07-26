using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
   private GameObject[] characterList;
   [SerializeField] float levelLoadDelay = 1.0f;
   public AudioClip right;
   public AudioClip left;
   public AudioClip play;
   AudioSource audioSource;
    private int index;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount]; 
       

        // Fill the array with the models
        for (int i = 0; i < transform.childCount; i++)
        
            characterList[i] = transform.GetChild(i).gameObject;

        // Toggle off their renderer
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // Toggle on the first index
        if(characterList[index])
            characterList[index].SetActive(true);
    }

    public void ToggleLeft()
    {
        audioSource.PlayOneShot(left);
        // Toggle off the current model
        characterList[index].SetActive(false);

        index--; // the same as index -=1; index = index -1;
        if (index < 0)
            index = characterList.Length - 1;

            // Toggle on the new model
            characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        audioSource.PlayOneShot(right);
        // Toggle off the current model
        characterList[index].SetActive(false);

        index++; 
        if (index == characterList.Length)
            index = 0;

            // Toggle on the new model
            characterList[index].SetActive(true);
    }

    public void PressPlay()
    {
    audioSource.PlayOneShot(play);
    Invoke ("LoadNextLevel", levelLoadDelay);
    }

      public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // minha cena e a ativa - ex:0
        int nextSceneIndex = currentSceneIndex +1; // proxima cena e a minha cena +1 - ex: 1

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) // se minha proxima cena e a ultima cena do total de cenas
        {
            nextSceneIndex = 0; // ai eu volto para a primeira cena
        }
        SceneManager.LoadScene(nextSceneIndex); //sempre vai procurar pela proxima
    }
}
