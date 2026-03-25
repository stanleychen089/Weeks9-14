using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public AudioSource footstepSFX;
    public List<AudioClip> footsteps; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Footstep()
    {
        footstepSFX.Play();
        //Debug.Log("Step!");
    }

    public void randomFootsteps()
    {
        int randomIndex = Random.Range(0, footsteps.Count);
        footstepSFX.clip = footsteps[randomIndex]; 
        footstepSFX.Play();
        Debug.Log(footsteps[randomIndex]);
    }
}
