using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrickshotJump : MonoBehaviour
{
    public float jumpSpeed;
    public AnimationCurve jumpCurve;
    bool jumpingTime = false;
    public float t = 0;
    public ParticleSystem jumpParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    jumpingTime = true;
        //    Debug.Log("Jump");
        //}
        if (jumpingTime)
        {
            t += Time.deltaTime*jumpSpeed;

         
            if (t > 1)
            {
                t = 0;
                jumpParticles.Emit(5);
                jumpingTime = false; 
            }

            Vector2 jumpPos = transform.position;
            jumpPos.y = jumpCurve.Evaluate(t);
            transform.position = jumpPos;
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        jumpingTime = true;
        Debug.Log("Jump");
        jumpParticles.Emit(5); 

    }
}
