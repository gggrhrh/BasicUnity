using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    Lobby,
    InGame,
}

public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void LoadScene(SceneType sceneType)
    {
        Logger.Log($"{sceneType} scene loading...");

        Time.timeScale = 1f; // 씬 전환 시 시간 스케일 초기화
        SceneManager.LoadScene(sceneType.ToString());
    }

    // 현재 씬을 다시 로드하는 메서드
    public void ReloadScene()
    {
        Logger.Log($"{SceneManager.GetActiveScene().name} scene loading...");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public AsyncOperation LoadSceneAsync(SceneType sceneType)
    {
       Logger.Log($"{SceneManager.GetActiveScene().name} scene loading...");

        Time.timeScale = 1f; // 씬 전환 시 시간 스케일 초기화
        
        return SceneManager.LoadSceneAsync(sceneType.ToString());
    }
}
