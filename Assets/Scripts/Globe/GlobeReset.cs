using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeReset : MonoBehaviour
{
    public Transform SpawnPosition;
    //public float disappearAfter;
    public float fadeTime;

    private float counter;
    private Vector3 OriginalScale;
    private bool fading = false;

    private void Start()
    {
        counter = 0;
        OriginalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {

    }

    public void WorldFadeIn()
    {
        if (!fading)
        {
            fading = true;
            StartCoroutine(WorldFadeInCoroutine());
        }
     
    }

    public void WorldFadeOut()
    {
        if (!fading)
        {
            fading = true;
            StartCoroutine(WorldFadeOutCoroutine());
        }

    }

    private IEnumerator WorldFadeInCoroutine()
    {
        
        if (transform.localScale != Vector3.zero)
        { 

            StartCoroutine(WorldFadeOutCoroutine());
            while (fading)
                yield return null;
            fading = true;
        }

        if (TryGetComponent(out Rigidbody rb))
            rb.velocity = Vector3.zero;

        transform.position = SpawnPosition.position;
        transform.rotation = SpawnPosition.rotation;

        counter = 0;
        while (counter < fadeTime)
        {
            transform.localScale = OriginalScale * (counter / fadeTime);
            counter += Time.deltaTime;
            yield return null;
        }

        transform.localScale = OriginalScale;

        fading = false;
    }

    private IEnumerator WorldFadeOutCoroutine()
    {
        counter = fadeTime;
        while (counter > 0)
        {
            transform.localScale = OriginalScale * (counter / fadeTime);
            counter -= Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;

        fading = false;
    }

}
