using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    float timer = 0f;
    [SerializeReference]
    public Text timerText;
    static bool playerAlive;

    private void Start()
    {
        playerAlive = true;
    }

    void Update()
    {
        if (playerAlive)
        {
            timer += Time.deltaTime;
            timerText.text = (Mathf.Floor(timer * 100f) / 100f).ToString();
        }
    }

    public static void StopTimer()
    {
        playerAlive = false;
    }
}
