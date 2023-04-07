using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeReference]
    Behaviour[] disableOnDeath;
    public float health = 1;
    Rigidbody2D rb;
    [SerializeReference]
    Image healthbar;
    [SerializeReference]
    GameObject gameover;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        if((healthbar != null) && (gameover != null))
        {
            healthbar.fillAmount = health;
        }

        StartCoroutine("HitMarker");
    }

    void Die()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        if (gameObject.tag == "Zombie")
        {
            Destroy(gameObject, 2f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Chronometer.StopTimer();
            gameover.SetActive(true);
        }

        foreach (Behaviour behaviour in disableOnDeath)
        {
            behaviour.enabled = false;
        }
    }

    IEnumerator HitMarker()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
