using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuckisaurMovement : MonoBehaviour
{
    //LEFT RIGHT MOVEMENT
    public float speed = 5;
    public Vector2 movement;

    //JUMPING
    public bool jumpingTime = false;
    public float jumpSpeed = 1;
    public float jumpStrength = 2;
    public float jumpHeight;
    public float t = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update transform to movement at specified speeds
        transform.position += (Vector3)movement * speed * Time.deltaTime;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed & !jumpingTime)
        {
            StartCoroutine(JumpTime());
        }

    }

    IEnumerator JumpTime()
    {
        yield return null;
    }

}
