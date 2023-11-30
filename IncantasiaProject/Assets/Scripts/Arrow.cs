using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float force = 2000.0f;
    public Transform tip = null;
    public Rigidbody rbArrow = null;
    public bool hitTarget = true;

    public Vector3 last_pos = Vector3.zero;

    public void Start(){
        rbArrow = GetComponent<Rigidbody>();
    }
    
    public void FixedUpdate() { // called by Unity
        if(hitTarget){
            return;
        }

        rbArrow.MoveRotation(Quaternion.LookRotation(rbArrow.velocity, transform.up));

        if(Physics.Linecast(last_pos, tip.position)){
            Stop();
        }
        last_pos = tip.position;
        
    }

    public void Stop(){
        hitTarget = true;

        rbArrow.isKinematic = true;
        rbArrow.useGravity = false;
    }

    public void Fire(float pullValue){
        hitTarget = false;

        rbArrow.isKinematic = false;
        rbArrow.useGravity = true;

        transform.parent = null;
        rbArrow.AddForce(transform.forward * pullValue * force);

        Destroy(gameObject, 5.0f);

    }
   
}
