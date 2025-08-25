using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private Rigidbody rb;

    public float mindirection = 0.5f;


    public GameObject sparksVFX;

    //Game Start only when Spacebar is hitted
    private bool stopped = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){}

    void FixedUpdate()
    {
        if (stopped) return;
        rb.MovePosition(rb.position +  direction * speed * Time.fixedDeltaTime);
    }


    //Collider OnTrigger
    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;
        if(other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            hit = true;
        }

        if(other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.mindirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.mindirection);
            direction = newDirection;
            hit = true;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        this.direction = new Vector3(0.5f * signX, 0, 0.4f * signZ);
    }


    public void Stop()
    {
        this.stopped = true;
    }
    public void Go()
    {
        ChooseDirection();
        this.stopped = false;
    }
}
