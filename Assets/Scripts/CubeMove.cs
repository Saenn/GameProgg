using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
 public class CubeMove : MonoBehaviour {

    //Variables
    public CharacterController playerControl;
    public float speed = 12.0F;
    public float runSpeed = 18.0F;
    public float jumpSpeed = 20.0F; 
    public float gravity = 30.0F;
    public bool checkActions;

    public bool isCollectDesertFlower = false;
    public bool isCollectMountainFlower = false;

    private float verticalVelocity = 0;
    private Vector3 moveDirection, prevMoveDirection;
    private float half = 0.5F;
     
     void Start () {
         checkActions = false;
		 playerControl = GetComponent<CharacterController>();
	}

     void Update() {
         
        if (Input.anyKey.Equals (false)) {
			checkActions = false;
		} else {
			checkActions = true;
		}

        if (playerControl.isGrounded) {
            if (Input.GetButton ("Jump")) {
                verticalVelocity = jumpSpeed + 5f -0.3f;
            } else {
                verticalVelocity = 0;
            }
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * runSpeed, verticalVelocity, Input.GetAxis("Vertical") * runSpeed);
        }
        else{
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, verticalVelocity, Input.GetAxis("Vertical") * speed);
        }
        
        moveDirection = transform.TransformDirection(moveDirection);
        playerControl.Move(moveDirection * Time.deltaTime);

         // is the controller on the ground?
        //  if (playerControl.isGrounded) {
            
        //     //Feed moveDirection with input.
        //      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //      moveDirection = transform.TransformDirection(moveDirection);
        //      //Multiply it by speed. 
             
        //      if(Input.GetKey(KeyCode.LeftShift)){
        //          moveDirection *= runSpeed;
        //      }
        //      else{
        //          moveDirection *= speed;
        //      }
        //      //Jumping
        //      if (Input.GetButton("Jump")){
        //          moveDirection.y = jumpSpeed;
        //          moveDirection.y += 12.0f;

        //      }
             
        //      //Applying gravity to the controller
        //     // moveDirection.y -= gravity * Time.deltaTime;
        //     // moveDirection.y -= 0.3f;
        //     //Making the character move
        //     playerControl.Move(moveDirection * Time.deltaTime);
        //     prevMoveDirection = moveDirection;
        //  }
        //  else{
        //     moveDirection = new Vector3(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
        //     moveDirection = transform.TransformDirection(moveDirection);
        //     //Applying gravity to the controller
        //     moveDirection.y -= gravity * Time.deltaTime;
        //     moveDirection.y -= 0.3f;
        //     //Making the character move
        //     playerControl.Move(moveDirection * Time.deltaTime);
        //  }
         
     }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cactus")) {
            speed = 6.0F;
            runSpeed = 9.0F;
            jumpSpeed = 10.0F;

            Wait();

            speed = 12.0F;
            runSpeed = 18.0F;
            jumpSpeed = 20.0F;
        }
        if(other.CompareTag("DesertFlower"))
        {
            isCollectDesertFlower = true;
        }
        if (other.CompareTag("MountainFlower"))
        {
            isCollectMountainFlower = true;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }



}