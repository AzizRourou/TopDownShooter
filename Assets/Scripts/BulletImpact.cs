using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeReference]
    GameObject prefab;
    [SerializeField]
    float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject hit = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(hit, duration);
        }
        if (collision.gameObject.tag == "Limits")
        {
            GameObject hit = Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(hit, duration);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject hit = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, 180f));
            Destroy(hit, duration);
        }
    }
}
