using UnityEngine;
using UnityEngine.InputSystem;

public class GymControllerInput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement = Vector2.zero;
    public Vector2 look = Vector2.zero;
    public float sensitivity = 200; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //object's transform will increase or decrease based on movement vector
        //affected by speed and deltaTime 
        transform.position += (Vector3)movement * speed * Time.deltaTime;

        //Object's eular rotation will increase or decrease based on look vector 
        //affected by sensitivity and deltaTime
        Vector3 direction = transform.eulerAngles;
        direction.z -= look.x * sensitivity * Time.deltaTime; 
        transform.eulerAngles = direction;
    }

    //function that reads movement input to trigger event
    public void OnMove(InputAction.CallbackContext context)
    {
        //read the value of the movement input 
        //links the movement vector to be the value of the movement input 
        //ReadValue<Vector2>(); so ReadValue can return a vector 2, which is what movement vector needs
        movement = context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
}
