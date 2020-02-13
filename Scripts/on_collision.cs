using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_collision : MonoBehaviour
{
    public enum coll_type { delete, disable }
    public coll_type type;
    public float radius;
    public float force;
    public float up_force;
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var item in colliders) {
            if (item.gameObject.GetComponent<Rigidbody>()) {
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, up_force);
            }
        }
        Destroy(Instantiate(Particle, transform.position, new Quaternion()), 5);
        switch (type) {
        case coll_type.disable:
            gameObject.SetActive(false);
            break;
        case coll_type.delete:
            Destroy(gameObject);
            break;
        default:
            break;
        }
    }
}
