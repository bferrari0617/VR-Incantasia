using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject barrel;
    public GameObject bullet;
    public new GameObject camera;
    bool isMouseButtonHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0)){
            isMouseButtonHeld = true;
            GameObject newBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.up * 1000);

            Destroy(newBullet, 4);
        }

        //AUTO FIRE
        if(isMouseButtonHeld && UnityEngine.Input.GetMouseButtonUp(0)){
            isMouseButtonHeld = false;
        }
        
    }
}
