using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    public UnityEvent OnMidPoint;

    [Tooltip("The renderer that we want to fade in and out. Must have a '_Color' color and should react to alpha changes")]
    public Renderer[] fadeObjects;
    public float sphereFadeTime;
    public float paddingTime;
    [Tooltip("This is automatically set to be the last loaded scene in the heirachy, but will be never be the first loaded scene (null if no loaded scenes)")]
    public Scene loadedScene;

    private void Start()
    {
        int lastLoadIndex = SceneManager.sceneCount-1;
        while (lastLoadIndex > 1)
        {
            if (SceneManager.GetSceneAt(lastLoadIndex).isLoaded)
            {
                loadedScene = SceneManager.GetSceneAt(lastLoadIndex);
                Debug.Log("Loaded Scene Name: " + loadedScene.name);
                break;
            }
            lastLoadIndex--;
        }

        if (instance == null)
            instance = this;
        else
        {
            Debug.LogError("There are two scene transition scripts in the scenes. There should only be one!");
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

            foreach (var helper in FindObjectsOfType<SceneTransitionHelper>())
                helper.OnTransitionStart.Invoke();

            Color[] fadeColors = new Color[fadeObjects.Length];
            for (int i = 0; i <fadeObjects.Length; i++)
                fadeColors[i] = fadeObjects[i].material.color;

            float counter = 0;
            while (counter <= sphereFadeTime)
            {
                yield return null;

                counter += Time.deltaTime;

                for (int i = 0; i < fadeObjects.Length; i++)
                    fadeColors[i].a = counter / sphereFadeTime;

                for (int i = 0; i < fadeObjects.Length; i++)
                    fadeObjects[i].material.color = fadeColors[i];
            }

            OnMidPoint.Invoke();

            AsyncOperation asyncload, asyncUnoad;
            if (loadedScene.IsValid())
            {
                asyncUnoad = SceneManager.UnloadSceneAsync(loadedScene);
                asyncload = SceneManager.LoadSceneAsync(toScene, LoadSceneMode.Additive);
                while (asyncUnoad.isDone && asyncload.isDone)
                    yield return null;
            }
            else
            {
                Debug.Log("Scene transition did not unload any scenes.");
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
            while (counter <= sphereFadeTime)
            {
                yield return null;

                counter += Time.deltaTime;

                for (int i = 0; i < fadeObjects.Length; i++)
                    fadeColors[i].a = 1 - (counter / sphereFadeTime);

                for (int i = 0; i < fadeObjects.Length; i++)
                    fadeObjects[i].material.color = fadeColors[i];
            }


            loadedScene = SceneManager.GetSceneByName(toScene);
            mutex = true;
        }
    }
}
