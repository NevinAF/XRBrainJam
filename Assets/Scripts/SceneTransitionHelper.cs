using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneTransitionHelper : MonoBehaviour
{
    public UnityEvent OnTransitionStart;

    public void ChangeScene(string toScene)
    {
        SceneTransition.instance.ChangeScene(toScene);
    }

    public void ShrinkWithFade(Transform trans)
    {
        StartCoroutine(Shrink(trans, SceneTransition.instance.sphereFadeTime));
    }

    public void ShrinkChildernWithFade(Transform parent)
    {
        foreach (Transform trans in parent)
            StartCoroutine(Shrink(trans, SceneTransition.instance.sphereFadeTime));
    }

    private IEnumerator Shrink(Transform trans, float time)
    {
        float counter = 0;
        Vector3 originalScale = trans.localScale;
        while (counter < time)
        {
            yield return null;

            counter += Time.deltaTime;
            trans.localScale = originalScale * (1 - (counter / time));
        }
    }
}
