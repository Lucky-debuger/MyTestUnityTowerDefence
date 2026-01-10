using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLoadScene : MonoBehaviour
{
    private int _index = 1;
    public void LoadScene()
    {
       StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync($"Level_0{_index}", LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // Почему делим на 0.9f

            Debug.Log($"Loading: {progress * 100:F1}%"); // Посмотреть про F

            yield return null;
        }

        Debug.Log("Scene loaded!");
        _index += 1;
    }
}
