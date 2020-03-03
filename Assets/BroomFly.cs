using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomFly : MonoBehaviour
{
    public float force = 1;

    void Update()
    {
        Vector3 direction = PerlinTest.Instance.GetValue(transform.position.x, transform.position.y);
        direction.x = Mathf.Lerp(-1, 1, direction.x);
        //direction.y = Mathf.Lerp(-1, 1, direction.y);
        direction.z = Mathf.Lerp(-1, 1, direction.z);
        GetComponent<Rigidbody>().AddForce(direction.normalized * force);
    }
}
