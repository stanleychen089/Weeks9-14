using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CactusHazard : MonoBehaviour
{
    public bool isInHazard = false;
    public UnityEvent OnHazard;
    public List<SpriteRenderer> cactusSRs;
    public DuckisaurMovement playerMovement;
    public float penaltyTime = 2;
    public float defaultSpeed = 5;
    public float t = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInHazard = false;
        //for each line used from Deadly Dungeon Challenge from week 7
        foreach (SpriteRenderer sr in cactusSRs)
        {
            if (sr.bounds.Contains(transform.position))
            {
                isInHazard = true;
            }
        }
        if (isInHazard)
        {
            OnHazard.Invoke();
            t = 0;
        }
        else
        {
            t += Time.deltaTime;
            if (t > penaltyTime)
            {
                playerMovement.speed = defaultSpeed;
            }
        }
    }

    public void HazardEffect()
    {
        playerMovement.speed = 2;

    }
}
