using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in FindObjectsOfType<Rigidbody>()) {
            var heading = item.transform.position - transform.position;
            float distance = (GetComponent<SphereCollider>().radius * transform.localScale).sqrMagnitude;
            if (heading.sqrMagnitude > distance/3) {
                Destroy(item.gameObject);
            }
        }
    }
}
