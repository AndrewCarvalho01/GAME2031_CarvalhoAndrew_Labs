using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float maxSpeed = 5f;

    private Rigidbody2D rb2D;

    private float input;
    private float linearVelocity;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb2D.linearVelocity.x) <= maxSpeed)
        {
            rb2D.AddForceX(input * moveForce);
        }
        else
        {
            if (Mathf.Sign(input) != Mathf.Sign(rb2D.linearVelocity.x))
            {
                rb2D.AddForceX(input * moveForce);
            }
        };
    }
}


