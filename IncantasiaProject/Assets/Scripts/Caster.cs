using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public OVRInput.Controller controllerType = OVRInput.Controller.None;
    public GameObject basicSpell;
    public Transform spellSpawn;


    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controllerType)){
            GameObject go = Instantiate(basicSpell, spellSpawn.position, spellSpawn.rotation);
            Destroy(go, 3);
        }    
    }
}