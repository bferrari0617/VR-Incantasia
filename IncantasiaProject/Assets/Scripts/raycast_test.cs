using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out RaycastHit hit, 2.0f)){
            if(hit.collider.tag == "Enemy"){
                Debug.Log("I hit an enemy.");
                enemy myEnemy = hit.transform.gameObject.GetComponent<enemy>();

                if(myEnemy != null){
                    myEnemy.getShot();
                }

            }
            else if(hit.collider.tag == "Friend"){
                Debug.Log("I hit a friend. Sorry friend.");
            }

        }

    }
}
