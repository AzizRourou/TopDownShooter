using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    string enemyTag;
    float timeColliding;
    float timeThreshold = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == enemyTag)
        {
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            if (timeColliding < timeThreshold)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
                timeColliding = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            timeColliding = 0f;
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }
}
