using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public SpriteRenderer treeSR;
    public Transform treeTransform;
    public Transform appleTransform;

    public float appleDelay = 1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ensures the tree starts with 0 so we do not have to configure it in the inspector 
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTreeGrowing()
    {
        StartCoroutine(GrowTree()); 
    }

    IEnumerator GrowTree()
    {
        float t = 0;
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        //a timer + if condition that functions like a while statement 
        //    t += Time.deltaTime; 
        //    if(t > 1)
        //    {
        //        //Stop the timer
        //    }
        //    treeTransform.localScale = Vector2.one * t; 

        //a while statement that functions like a timer 
        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }

        yield return new WaitForSeconds(appleDelay); 

        t = 0; 

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t * 2;
            yield return null;
        }
    }
}

