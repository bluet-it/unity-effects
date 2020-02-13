using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_collision : MonoBehaviour
{
    public GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>()) {
            Destroy(collision.gameObject);
        }
        Destroy(Instantiate(Particle, transform.position, new Quaternion(0, 0, 0, 0)), 3
            );
        Destroy(gameObject);
    }
}
