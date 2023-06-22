using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float gravity=-9.81f;
    public float jumpHeight=3f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Vector2 minBoundary;
   public Vector2 maxBoundary;
    
    void Start()
    {
        
    }

    void Update()
    {
        move();

       
        
    }

    
    void move()
    {
        // ground check
       isGrounded=Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
       if(isGrounded && velocity.y<0)
       {
         velocity.y=-2f;
       }
        // Inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right*horizontal+ transform.forward*vertical;
       
        controller.Move(movement*moveSpeed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            velocity.y=Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity *Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
