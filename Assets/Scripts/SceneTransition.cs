using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Tooltip("The renderer that we want to fade in and out. Must have a '_Color' color and should react to alpha changes")]
    public Renderer cullingSphere;
    public float sphereFadeTime;
    public float paddingTime;

    public Scene loadedScene;

    private void Start()
    {
        if (SceneManager.sceneCount >= 2)
        {
            loadedScene = SceneManager.GetSceneAt(1);
        }
    }

    /// <summary>
    /// Assumes that there is only two scenes, and unloads the second.
    /// </summary>
    /// <param name="toScene">The scene that will be loaded.</param>
    public void ChangeScene(string toScene)
    {
        StartCoroutine(LoadScene(toScene));
    }

    public void ChangeScene(string fromScene, string toScene)
    {
        loadedScene = SceneManager.GetSceneByName(fromScene);
        ChangeScene(toScene);
    }

    private bool mutex = true;
    private IEnumerator LoadScene(string toScene)
    {
        if (!mutex)
        {
            Debug.LogWarning("Cannot transition scenes while in the middle of another scene transition");
        }
        else
        {
            mutex = false;

            Color sphereColor = cullingSphere.material.color;
            float counter = 0;
            while (counter < sphereFadeTime)
            {
                sphereColor.a = counter / sphereFadeTime;
                cullingSphere.material.color = sphereColor;
                counter += Time.deltaTime;
                yield return null;
            }


            AsyncOperation asyncload, asyncUnoad;
            if (loadedScene != null)
            {
                asyncUnoad = SceneManager.UnloadSceneAsync(loadedScene);
                asyncload = SceneManager.LoadSceneAsync(toScene, LoadSceneMode.Additive);
                while (asyncUnoad.isDone && asyncload.isDone)
                    yield return null;
            }
            else
            {
                Debug.LogWarning("Scene transition did not unload any scenes.");
                asyncload = SceneManager.LoadSceneAsync(toScene, LoadSceneMode.Additive);
                while (asyncload.isDone)
                    yield return null;
            }
                
            counter = 0;
            while (counter < paddingTime)
            {
                counter += Time.deltaTime;
                yield return null;
            }

            counter = 0;
            while (counter < sphereFadeTime)
            {
                sphereColor.a = 1 - (counter / sphereFadeTime);
                cullingSphere.material.color = sphereColor;
                counter += Time.deltaTime;
                yield return null;
            }


            loadedScene = SceneManager.GetSceneByName(toScene);
            mutex = true;
        }
    }
}
