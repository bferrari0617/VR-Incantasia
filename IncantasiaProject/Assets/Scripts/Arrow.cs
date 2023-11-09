using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float force = 2000.0f;
    public Transform tip = null;
    public Rigidbody rbArrow = null;
    public bool hitTarget = true;

    public Vector3 last_pos = Vector3.zero;

    public void Start(){
        
    }
   
}
