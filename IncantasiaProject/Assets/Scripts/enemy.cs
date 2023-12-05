using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public float life = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            Destroy(transform.gameObject, 1.0f);
        }

        
    }

    public void getShot(){
        life -= 250;
    }
}
