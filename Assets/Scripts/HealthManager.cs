using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public Behaviour[] disableOnDeath;
    float health = 1;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float amount)//, Vector3 lethalObjectPos, float pushForce)
    {
        //Vector2 pushDirection = transform.position - lethalObjectPos;
        //rb.AddForce(pushDirection.normalized * pushForce, ForceMode2D.Impulse);

        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    void Die()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        if (gameObject.tag == "Zombie")
        {
            Destroy(gameObject, 2f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }

        //Disable all the components inside the disableOnDeath array that you will assign from the inspector
        foreach (Behaviour behaviour in disableOnDeath)
        {
            behaviour.enabled = false;
        }
    }
}
