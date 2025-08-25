using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode up;
    public KeyCode down;
    private Rigidbody rb;

    public bool isPlayer = true;
    private Transform ball;
    public float offset = 0.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (this.isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }
    }

    private void MoveByPlayer()
    {
        bool pressedUp = Input.GetKey(this.up);
        bool pressedDown = Input.GetKey(this.down);

        if (pressedUp)
        {
            rb.linearVelocity = Vector3.forward * speed;
        }

        if (pressedDown)
        {
            rb.linearVelocity = Vector3.back * speed;
        }

        if (!pressedUp && !pressedDown)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }


    private void MoveByComputer()
    {
        if (ball.position.z > transform.position.z + offset)
        {
            rb.linearVelocity = Vector3.forward * speed;
        }
        else if (ball.position.z < transform.position.z - offset)
        {
            rb.linearVelocity = Vector3.back * speed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
