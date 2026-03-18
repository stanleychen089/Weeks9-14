using System.Collections;
using UnityEngine;

public class Grower2 : MonoBehaviour
{
    public Transform treeTransform;
    public Transform duckAppleTransform;
    public float appleDelay = 1;

    Coroutine doTheGrowingCoroutine;
    Coroutine growTreeCoroutine;
    Coroutine growAppleCoroutine; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        duckAppleTransform.localScale = Vector2.zero; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        if (doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if (growTreeCoroutine != null)
        {
            StopCoroutine(growTreeCoroutine);
        }
        if (growAppleCoroutine != null)
        {
            StopCoroutine(growAppleCoroutine);
        }
        doTheGrowingCoroutine = StartCoroutine(DoTheGrowing());
    }

    IEnumerator DoTheGrowing()
    {
        yield return growTreeCoroutine = StartCoroutine(GrowTree());
        yield return growTreeCoroutine = StartCoroutine(GrowApple());
    }

    IEnumerator GrowTree()
    {
        Debug.Log("Started Growing Tree");
        treeTransform.localScale = Vector2.zero;
        duckAppleTransform.localScale = Vector2.zero;

        float t = 0; 

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished Growing Tree");
    }

    IEnumerator GrowApple()
    {
        Debug.Log("Started Growing Apple");
        duckAppleTransform.localScale = Vector2.zero;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            duckAppleTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished Growing Apple");
    }



}
