using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicate : MonoBehaviour
{
    public GameObject element;
    public Vector3 offset;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++) {
            Instantiate(element, offset * i + element.transform.position, new Quaternion(0, 0, 0, 0));
        }
        Destroy(element);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
