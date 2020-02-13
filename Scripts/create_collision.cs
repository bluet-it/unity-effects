using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_collision : MonoBehaviour
{
    public GameObject Particle;
    public int amount;
    public float radius;
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
            for (int i = 0; i < amount; i++) {
                GameObject go = Instantiate(collision.gameObject, transform.position + (Random.insideUnitSphere * radius), new Quaternion());
                go.GetComponent<Rigidbody>().AddForce(collision.impulse * -1,ForceMode.VelocityChange);
                Destroy(go, 5);
            }
            Destroy(collision.gameObject);
        } else {
            for (int i = 0; i < amount; i++) {
                GameObject go = Instantiate(gameObject, transform.position + (Random.insideUnitSphere * radius), new Quaternion());
                go.GetComponent<Rigidbody>().AddForce(collision.impulse, ForceMode.VelocityChange);
                Destroy(go.GetComponent<create_collision>());
                Destroy(go.GetComponentInChildren<ParticleSystem>().gameObject);
                Destroy(go, 5);
            }
        }
        Destroy(Instantiate(Particle, transform.position, new Quaternion()), 5);
        Destroy(gameObject);
    }
}
