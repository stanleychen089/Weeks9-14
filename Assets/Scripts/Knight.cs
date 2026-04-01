using NUnit.Framework;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Knight : MonoBehaviour
{
    //animation events
    public AudioSource footstepSFX;
    public List<AudioClip> footsteps;
    public CinemachineImpulseSource impulseSource;
    public Animator animator;
    public SpriteRenderer srDirections; 
    //on click movement
    public Vector2 startPos;
    public Vector2 endPos;
    public float t = 0;
    public AnimationCurve curve;
    public bool isWalking = false;
    public Vector2 mousePos;
    //tilemap check 
    public Tilemap tilemap;
    public Vector3Int cellPos;
    public Tile pavement;
    public Tile crackedPavement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(isWalking == true)
        {
            animator.SetBool("isWalking", true); 
            t += Time.deltaTime / 3;
            transform.position = Vector2.Lerp(startPos, endPos, curve.Evaluate(t));
            if (t > 1)
            {
                t = 0;
                startPos = endPos;
                animator.SetBool("isWalking", false);
                isWalking = false;

            }
        }
        //check if player is moving left or right
        if(startPos.x < endPos.x)
        {
            srDirections.flipX = false; 
        }
       else if (startPos.x > endPos.x)
        {
            srDirections.flipX = true;
        }


    }
    public void Footstep()
    {
        footstepSFX.Play();
        //Debug.Log("Step!");
        impulseSource.GenerateImpulse();

    }

    public void randomFootsteps()
    {
        Vector2 playerPos = transform.position;
        Vector3Int playerCellPos = tilemap.WorldToCell(playerPos);
        int randomIndex = Random.Range(0, footsteps.Count);
        footstepSFX.clip = footsteps[randomIndex];
        if (tilemap.GetTile(playerCellPos) == pavement || tilemap.GetTile(playerCellPos) == crackedPavement)
        {
            footstepSFX.Play();
            tilemap.SetTile(playerCellPos, crackedPavement);

        }
       
        impulseSource.GenerateImpulse();

      //  Debug.Log(footsteps[randomIndex]);
    }
    
    public void OnPoint(InputAction.CallbackContext context)
    {
        
         mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
         cellPos = tilemap.WorldToCell(mousePos);
         Debug.Log(tilemap.GetTile(cellPos));
        
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (isWalking == false & tilemap.GetTile(cellPos) == pavement)
        {
            isWalking = true;
            startPos = transform.position;
            endPos = mousePos;
        }
    }
}
