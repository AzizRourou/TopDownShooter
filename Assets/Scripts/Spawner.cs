using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int distance;
    public GameObject toSpawnPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 3f, 3);
    }

    void Spawn()
    {
        Vector2 position = RandomInCircle(distance);
        Instantiate(toSpawnPrefab, position, Quaternion.identity);
    }

    Vector3 RandomInCircle(float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = gameObject.transform.position.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = gameObject.transform.position.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = 0;
        return pos;
    }
}
