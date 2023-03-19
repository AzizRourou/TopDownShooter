using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour
{
    public float damage;
    public string enemyTag;
    //public float pushForce;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == enemyTag)
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);//, transform.position, pushForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);//, transform.position, pushForce);
        }
    }
}
