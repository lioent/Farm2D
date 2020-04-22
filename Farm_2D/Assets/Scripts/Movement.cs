using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody != null)
        {
            float xInput = Input.GetAxis("Horizontal");
            float xForce = xInput * speed * Time.deltaTime;
            Vector2 force = new Vector2(xForce, 0);

            rigidbody.AddForce(force);
        }
        else
        {
            Debug.LogWarning("Rigid body not attached to the GameObject " + gameObject.name);
        }
    }
}
