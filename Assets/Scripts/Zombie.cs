using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Transform player;
    Vector2 dir;
    float angle = 0f;
    Rigidbody2D rb;
    float speed = 3.5f;
    [SerializeField]
    float speedLowerBound;
    [SerializeField]
    float speedUpperBound;
    [SerializeField]
    float healthLowerBound;
    [SerializeField]
    float healthUpperBound;
    HealthManager hm;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hm = GetComponent<HealthManager>();
        RandomizeZombieState();
        Debug.Log("speed=" + speed + " health=" + hm.health);
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (player)
        {
            dir = (player.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = dir * speed;
        if(dir != Vector2.zero)
        {
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }
        
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Limits")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }

    void RandomizeZombieState()
    {
        speed = Random.Range(speedLowerBound, speedUpperBound);
        hm.health = Random.Range(healthLowerBound, healthUpperBound);
    }
}

