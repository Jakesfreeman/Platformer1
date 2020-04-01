using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public int currentScene = 0;


    public int playerScore = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(this.gameObject);
            Debug.Log("second gameManager was created and deleted");
        }
    }


    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
        currentScene++;

    }


    public void Loadlevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }


    public void loadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
