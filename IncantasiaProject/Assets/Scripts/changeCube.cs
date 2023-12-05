using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCube : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(3,3,3);
        //transform.localRotation = new Quaternion(0,30,0,0);
        //transform.Rotate(0,1,1);
        //transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f);
    }
}
