using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    Transform player;
    Vector2 dir;
    float angle = 0f;
    Rigidbody2D rb;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (player)
        {
            dir = (player.position - transform.position).normalized;
        }
    }
    // Update is called once per frame
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
}

