using UnityEngine;

public class ball : MonoBehaviour
{

    public Rigidbody2D ballRB;
    public Vector2 tf;
    public Vector2 velocityPrev;

    public int speed;
    public int acel;
    public int _incrementVelocity;


    private void Awake()
    {
        
        GameManager.Instance.Ball = this;
    }

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {

        float v = Random.Range(0.4f, 1f);
        float x = v * (Random.Range(0, 2) == 0 ? -1 : 1);
        float y = v * (Random.Range(0, 2) == 0 ? -1 : 1);

        transform.position = Vector2.zero;

        ballRB.velocity = speed * (new Vector2(x, y).normalized);

        //relativeVelocity

    }


    private Vector2 Accelerate(Vector2 velocity)
    {
        return _incrementVelocity * velocity.normalized;
    }


    private void FixedUpdate()
    {
        velocityPrev = ballRB.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                ballRB.velocity = velocityPrev + Accelerate(velocityPrev);

                ballRB.velocity = new Vector2(-ballRB.velocity.x, ballRB.velocity.y);

                break;
            case "Walls":

                ballRB.velocity = velocityPrev;

                ballRB.velocity = new Vector2(ballRB.velocity.x, -ballRB.velocity.y);

                break;
                /*
                if (ballRB.velocity.x > 0)
                {
                    ballRB.velocity = new Vector2(ballRB.velocity.x + acel, transform.position.y);
                }
                else
                {
                    ballRB.velocity = new Vector2(ballRB.velocity.x - acel, transform.position.y);
                }
                break;
                */
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (ballRB != null)
        {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + ballRB.velocity);
        }
    }

}
