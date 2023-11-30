using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Animator anime = null;
    public float pullValue = 0.0f;

    public Transform start_pos = null;
    public Transform end_pos = null;
    public Transform socket_pos = null;

    public Transform pullHand = null;
    public Arrow current;
    public GameObject arrowPrefab = null;

    public void Awake(){
        anime = GetComponent<Animator>();
    }

    public void Start(){
        StartCoroutine(createArrow(0.0f));
    }

    public IEnumerator createArrow(float waitingTime){
        yield return new WaitForSeconds(waitingTime);

        GameObject newArrow = Instantiate(arrowPrefab, socket_pos);
        newArrow.transform.localPosition = new Vector3(0, 0, 0.425f);
        newArrow.transform.localEulerAngles = Vector3.zero;
        current = newArrow.GetComponent<Arrow>();
    }

    public void Update(){
        if (!pullHand || !current)
            return;

        pullValue = CalcPull(pullHand);
        pullValue = Mathf.Clamp(pullValue, 0.0f, 1.0f);

        anime.SetFloat("Blend", pullValue);
    }

    public float CalcPull(Transform hand){
        Vector3 direction = end_pos.position - start_pos.position;
        float magnitude = direction.magnitude;
        direction.Normalize();

        Vector3 difference = hand.position - start_pos.position;


        return Vector3.Dot(difference, direction)/magnitude;
    }

    public void Pull(Transform hand){
        float distance = Vector3.Distance(hand.position, start_pos.position);

        if(distance < 0.25f){
            return;
        }

        pullHand = hand;
    }

    public void Release(){
        if(pullValue > 0.25f){
            fireArrow();
            pullHand = null;
            pullValue = 0.0f;
            anime.SetFloat("blend", 0.0f);
            if(!current){
                StartCoroutine(createArrow(0.25f));
            }
        }
    }

    public void fireArrow(){
        current.Fire(pullValue);
        current = null;

    }

}
