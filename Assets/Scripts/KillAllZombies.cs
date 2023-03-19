using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllZombies : MonoBehaviour
{
    //Script for GoMyCode's "C# Loops and Arrays" checkpoint
    GameObject[] zombies;

    //for each frame update the array of zombies is updated, and if "K" is pressed -> all the zombies get killed
    void Update()
    {
        //array is updated and number of zombies is printed in the console
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        Debug.Log(zombies.Length);

        //if button pressed -> destroy all zombies
        if (Input.GetKeyDown("k"))
        {
            foreach(GameObject zombie in zombies)
            {
                Destroy(zombie);
            }
        }
    }
}
