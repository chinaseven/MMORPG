using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureColliderArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Achou");
        if (other.gameObject.tag=="player")
            GetComponentInParent<CreatureControl>().creatureTarget = other.transform;
    }
}
