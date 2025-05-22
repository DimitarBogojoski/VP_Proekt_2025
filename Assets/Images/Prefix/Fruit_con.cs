using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_con : MonoBehaviour
{
    private string InTheCloud = "y";
    void Start()
    {
        
    }

    
    void Update()
    {
        if(InTheCloud == "y")
        {
            GetComponent<Transform>().position = Cloud.cloudxPos;
        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            InTheCloud = "n";
            Cloud.spawnYet = "n";
        }
    }
}
