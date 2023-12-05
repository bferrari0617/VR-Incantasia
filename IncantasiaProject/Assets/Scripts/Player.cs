using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController character = null;
    public new Transform camera = null;
    public float cameraPos = 0.0f;
    public float mouseSens = 3.5f;
    public float speed = 6.0f;
    private float gravity = -9.81f;
    public float gravityMultiplier = 6.0f;
    public float yVelocity;
    public float jumpForce = 3.0f; // Adjust the jump force as needed
    Vector3 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        movePlayer();
        Jump();
        Sprint();
        applyGravity();

    }

    public void moveCamera(){
        //CAMERA MOVEMENT
        //converting mouse input into vector2 "mouseDir"
        Vector2 mouseDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //alter y-axis camera pos value using mouseDir.y
        cameraPos = cameraPos - mouseDir.y * mouseSens;
        //cannot rotate camera pos value past 90 deg
        cameraPos = Mathf.Clamp(cameraPos, -90, 90);
        //update camera pos using camera pos value
        camera.localEulerAngles = cameraPos * Vector3.right;

        //alters x-axis camera pos using mouseDir.x
        transform.Rotate(Vector3.up * mouseDir.x * mouseSens);

    }

    public void movePlayer(){
        //PLAYER MOVEMENT
        //converting WASD input into vector2 "playerDir"
        Vector2 playerDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerDir.Normalize();

        //transform.forward is the forward/backward position of the player
        //transform.right is the left/right position of the player
        //the displacement of the player is stored in vector3 "playerMove"
        playerMove = transform.forward * playerDir.y * speed + transform.right * playerDir.x * speed + transform.up * yVelocity * gravityMultiplier;
        //applies playerMove vector to control player movement
        character.Move(playerMove * Time.deltaTime);

    }
    
    public void Jump(){
        //if in the air, you are not allowed to jump
        if (!IsGrounded()) return;

        //else, if on the ground
        yVelocity = -1.0f;
        // Apply an upward force to simulate jumping
        if(Input.GetKey(KeyCode.Space)){
            yVelocity = jumpForce;
        }
    }

    public void applyGravity(){
        //if in the air
        if(!IsGrounded()){
            yVelocity += gravity * Time.deltaTime;
        }        
    }

    public void Sprint(){

        //Implementing Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            // Code to start the action when the left Shift key is pressed.
            speed = 12.0f;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            // Code to stop the action when the left Shift key is released.
            speed = 6.0f;
        }
    }
    
    private bool IsGrounded() => character.isGrounded;

}
