using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_oculus : MonoBehaviour
{
    public CharacterController player;
    public Transform headset;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // move based on button input
        // if(OVRInput.Get(OVRInput.Button.One)){
        //     Vector3 whereToGo = headset.localRotation * new Vector3(0.0f,0.0f,1.0f);
        //     player.Move(whereToGo * speed * Time.deltaTime);
        // }

        // 2D vector, x and y
        var joyStickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);

        // create 3D vector because character can only move in 3D space
        Vector3 movePos = (transform.right * joyStickAxis.x + transform.forward * joyStickAxis.y);
        player.Move(movePos * speed * Time.deltaTime);


    }
}
