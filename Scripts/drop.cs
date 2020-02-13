using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public GameObject target;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject go = Instantiate(target, transform.position, new Quaternion(0,0,0,0));
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            go.GetComponent<Rigidbody>().AddForce(ray.direction * 30, ForceMode.VelocityChange);
        }
    }
}
