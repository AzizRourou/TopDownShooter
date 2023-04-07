using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeReference]
    Transform target;

    void Update()
    {
        transform.position = target.transform.position;
    }
}
