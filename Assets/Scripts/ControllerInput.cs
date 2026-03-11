using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource SFX; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use with a stick
        //transform.position += (Vector3)movement * speed * Time.deltaTime;
        //use with the mouse position
        transform.position = movement; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack " + context.phase);
        if(context.performed == true)
        {
            SFX.Play(); 
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //Same as Mouse.Current.position.ReadValue()
        //Using the InputSystem to control the mouse so systems or objects that reacts to the mouse--
        //--do not all react at the same time 
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()); 
    }
}
