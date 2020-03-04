using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomFly : MonoBehaviour
{
    public float force = 1;
    public float maxSpeed = 8;

    void Update()
    {
        Vector3 direction = PerlinTest.Instance.GetValue(transform.position.x, transform.position.y);
        direction.x = Mathf.Lerp(-1, 1, direction.x);
        direction.y *= 2f;
        direction.z = Mathf.Lerp(-1, 1, direction.z);
        var rb = GetComponent<Rigidbody>();
        rb.AddForce((direction.normalized + (direction.normalized.y * transform.up * 3f)) * force );
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
