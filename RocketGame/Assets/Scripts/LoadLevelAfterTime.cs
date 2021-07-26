using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoading = 2f;
    
    

    private float timeElapsed;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
          LoadNextLevel();
        }

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
}
