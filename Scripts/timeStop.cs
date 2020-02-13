using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeStop : MonoBehaviour
{
    public float multiplier;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!activated) {
            Time.timeScale = multiplier;
            GameObject particle = Instantiate(Particle, transform.position, new Quaternion(), transform);
            activated = true;
            Destroy(GetComponentInChildren<ParticleSystem>().gameObject);
            Destroy(gameObject, delay);
            Destroy(particle, delay);
        }
    }
    private void OnDestroy()
    {
        if (activated) {
            bool a = false;
            foreach (var item in FindObjectsOfType<timeStop>()) {
                if (item.activated) {
                    a = true;
                }
            }
            if (!a) {
                Time.timeScale = 1;
            }
        }
    }
}
