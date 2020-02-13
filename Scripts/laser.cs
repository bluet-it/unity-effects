using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LineRenderer>().positionCount = 2;

        RaycastHit raycast = new RaycastHit();
        if (Physics.Raycast(new Ray(transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction), out raycast)) {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPositions(new Vector3[] {transform.position, raycast.point});
            if (raycast.collider.gameObject.GetComponent<Rigidbody>()) {
                Destroy(raycast.collider.gameObject);
            }
        } else {
            GetComponent<LineRenderer>().enabled = false;
        }
        if (!Input.GetMouseButton(0)) {
        Destroy(gameObject);
        }
    }
}
