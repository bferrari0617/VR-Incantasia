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

    public void FixedUpdate() {
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

    public void Fire(){
        hitTarget = false;
        rbArrow.isKinematic = false;
        rbArrow.useGravity = true;
        
    }
   
}
