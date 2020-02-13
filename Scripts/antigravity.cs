using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antigravity : MonoBehaviour
{
    public float radius;
    public float delay;
    public GameObject Particle;

    private bool activated;
    private GameObject[] objects;
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
        if (!activated) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var item in colliders) {
                if (item.gameObject.GetComponent<Rigidbody>()) {
                    item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            objects = new GameObject[colliders.Length];
            for (int i = 0; i < colliders.Length; i++) {
                objects[i] = colliders[i].gameObject;
            }
            GameObject particle = Instantiate(Particle, transform.position, new Quaternion(), transform);
            particle.GetComponent<ParticleSystem>().loop = true;
            activated = true;
            Destroy(GetComponentInChildren<ParticleSystem>().gameObject);
            Destroy(gameObject, delay);
            Destroy(particle, delay);
        }
    }
    private void OnDestroy()
    {
        if (activated) {
            foreach (var item in objects) {
                if (item.GetComponent<Rigidbody>()) {
                    item.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }
}
