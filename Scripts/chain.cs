using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain : MonoBehaviour
{
    public GameObject element;
    public Vector3 offset;
    public int amount;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = new GameObject[amount];
        for (int i = 0; i < amount; i++) {
            objects[i] = Instantiate(element, offset * i + element.transform.position, new Quaternion(0, 0, 0, 0));
            objects[i].AddComponent<Rigidbody>();
        }
        for (int i = 0; i < amount-1; i++) {
            objects[i].AddComponent<HingeJoint>();
            objects[i].GetComponent<HingeJoint>().connectedBody = objects[i + 1].GetComponent<Rigidbody>();
            objects[i].GetComponent<HingeJoint>().breakForce = force;
        }
        objects[0].GetComponent<Rigidbody>().isKinematic = true;
        objects[objects.Length-1].GetComponent<Rigidbody>().isKinematic = true;
        Destroy(element);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
