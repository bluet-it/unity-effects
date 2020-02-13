using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20);
        foreach (var item in colliders) {
            if (item.GetComponent<Rigidbody>()) {
                item.GetComponent<Rigidbody>().AddExplosionForce(-200, transform.position, 20, 0, ForceMode.Force);
            }
        }
    }
}
