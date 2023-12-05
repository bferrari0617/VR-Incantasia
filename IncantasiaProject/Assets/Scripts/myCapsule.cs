using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCapsule : MonoBehaviour
{
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            health -= 1;
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            transform.Translate(0.0f,0.0f,1.0f);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            transform.Translate(0.0f,0.0f,-1.0f);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.Translate(-1.0f,0.0f,0.0f);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.Translate(1.0f,0.0f,0.0f);
        }

    }


}
