using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ANIMATOR
    public Animator animator;
    public bool isGrounded = true;

    //SPEED VARIABLES
    public float playerMovementSpeed = 5;
    public static float slowTimer = 0f;
    public float slowMovementSpeed = 2.5f;
    
    //JUMP VARIABLES
    float jumpForce = 15;
    float gravity = -9.81f;
    float gravityScale = 5;
    float velocity;
    float jumpDelay;
    float desiredJumpDelay = 0.7f;


    //LANE LOGIC VARIABLES
    public int desiredLane = 0;
    public float laneDistance = 1.5f;
    public float laneChangeSpeed = 5;
    
    //SYSTEM CURRENTLY IN USE: Moving across lanes by clicking the directional buttons
    private void Update()
    {
        slowTimer -= Time.deltaTime;
        if(slowTimer > 0 && jumpDelay < desiredJumpDelay)
        {
            transform.Translate(Vector3.forward * playerMovementSpeed * Time.deltaTime, Space.World);
        }
        else if(slowTimer > 0)
        {
            transform.Translate(Vector3.forward * slowMovementSpeed * Time.deltaTime, Space.World);

        }
        else
        {
            transform.Translate(Vector3.forward * playerMovementSpeed * Time.deltaTime, Space.World);
        }
        
        //Moves left
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(desiredLane > -1)
            {
                desiredLane--;
            }
        }

        //Moves right
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(desiredLane < 1)
            {
                desiredLane++;
            }
        }
        
        //Brings the player to the ground after jumping
        //Stops the player from falling through the ground
        velocity += gravity * gravityScale * Time.deltaTime;
        if(transform.position.y <=1.25 && velocity < 0)
        {
            transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
            velocity = 0;
            if(velocity == 0)
            {
                isGrounded = true;
            }
        }

        //Jumps
        if(Input.GetKeyDown(KeyCode.Space) && jumpDelay >= desiredJumpDelay)
        {
            jumpDelay = 0;
            velocity = jumpForce;
            isGrounded = false;
        }

        if(isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        //Stops the player from being able to spam jump
        jumpDelay += Time.deltaTime;
        
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

        //Changes lanes based on desired lane
        if(desiredLane == -1)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 1)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,laneChangeSpeed*Time.deltaTime);
    }
}
