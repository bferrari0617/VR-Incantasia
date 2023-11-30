using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController character = null;
    public float speed = 6.0f;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerDir.Normalize();
        Vector3 playerMove  = (transform.forward * playerDir.y + transform.right * playerDir.x);

        character.Move(playerMove* Time.deltaTime * speed);
    }
}
