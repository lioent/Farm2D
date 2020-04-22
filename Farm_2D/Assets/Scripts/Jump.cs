using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private int maxJumps = 1;
    public float jumpForce = 500f;
    public int jumps;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
        jumps = maxJumps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody != null)
        {
            if (jumps > 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rigidbody.AddForce(new Vector2(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
                    jumps--;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody != null)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                jumps = maxJumps;
            }
        }
    }
}
