using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralGameMenager : MonoBehaviour
{
    public static GeneralGameMenager instance;
    public PlayerData data;
    void Awake()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
        DontDestroyOnLoad(gameObject);
        data = SaveMenager.Load();
        SceneManager.LoadScene(data.currentSceneIndex);
    }

    private void OnLevelWasLoaded(int level)
    {
        data = SaveMenager.Load();
    }

}
