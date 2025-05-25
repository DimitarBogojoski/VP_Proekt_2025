using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_con : MonoBehaviour
{
    private string InTheCloud = "y";
    void Start()
    {
        if (transform.position.y < 4.1)
        {
            InTheCloud = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
       }
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Cloud.spawnPos=transform.position;
            Cloud.newFruit = "y";
            Cloud.witchFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
