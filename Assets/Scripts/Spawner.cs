using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int distance;
    [SerializeReference]
    GameObject toSpawnPrefab;

    Vector2 position;

    public int wave = 10;
    public int increment = 4;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, 20f);
    }

    void Spawn()
    {
        for(int i=0; i<wave; i++)
        {
            position = RandomInCircle(distance);
            Instantiate(toSpawnPrefab, position, Quaternion.identity);
        }
        wave += increment;
        increment += 1;
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
