using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuckisaurMovement : MonoBehaviour
{
    //LEFT RIGHT MOVEMENT
    public float speed = 5;
    public float defaultSpeed = 5;
    public Vector2 movement;

    //JUMPING
    public bool isJumping = false;
    public float jumpSpeed;
    public float jumpHeight;
    public Transform startPos; 

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
        //calls the jump and land courtines when spacebar is pressed and if player is not already jumping
        if (context.performed & !isJumping)
        {
            StartCoroutine(doTheJumping());
        }

    }
    //coroutine hub so players can only fall after they jump
    IEnumerator doTheJumping()
    {
        yield return Jump();
        yield return Land();
    }
    //coroutine that increases the player height based on the starting position of an empty game object set to the floor
    IEnumerator Jump()
    {
        //set timer to 0
        //increase timer during while statement
        //set isJumping to true so players can't jump while jumping
        //increase player position based on starting position and t
        //multiple t to a jumpSpeed to increase jumpSpeed
        //yield return null so coroutine functions properly
        float t = 0;
        while (t < jumpHeight)
        {
            isJumping = true; 
            t += Time.deltaTime;
            Vector2 jumpPos = transform.position;
            jumpPos.y = startPos.position.y + t * jumpSpeed;
            transform.position = jumpPos;
            yield return null;
        }    
    }
    //coroutine that decreases the player height based on the starting position of the current height determined at the jump's vertex

    IEnumerator Land()
    {
        float t = 0;
        float currentY = transform.position.y;
        while (transform.position.y > startPos.position.y)
        {
            t -= Time.deltaTime;
            Vector2 jumpPos = transform.position;
            jumpPos.y = currentY + t * jumpSpeed;
            transform.position = jumpPos;
            yield return null;
        }
        isJumping = false;
    }

    public void RestartPosition()
    {
        Debug.Log("Restart Pressed");
       
        transform.position = startPos.position;
        speed = defaultSpeed;
        
    }
}
