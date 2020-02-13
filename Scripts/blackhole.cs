using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    public float radius;
    public float force;
    public float delay;
    public GameObject Particle;

    private bool activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var item in colliders) {
                if (item.gameObject.GetComponent<Rigidbody>()) {
                    item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, 0, ForceMode.Force);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!activated) {
            GameObject particle = Instantiate(Particle, transform.position, new Quaternion(), transform);
            particle.GetComponent<ParticleSystem>().loop = true;
            activated = true;
            Destroy(GetComponentInChildren<ParticleSystem>().gameObject);
            Destroy(gameObject, delay);
            Destroy(particle, delay);
        }
    }
}
