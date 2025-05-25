using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnYet = "n";
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    static public string newFruit="n";
    static public int witchFruit=0;

    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnFruit();
        ReplaceFruit();

        if (Input.GetKey("a")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }

        if(Input.GetKey("d")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2,0);
        }
        if((!Input.GetKey("a")) && (!Input.GetKey("d"))){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

        cloudxPos=transform.position;

        if((Input.GetKeyDown("space")) && (spawnYet == "y")) {
            spawnYet = "n";
        }
        
    }


    void SpawnFruit()
    {
        if(spawnYet == "n")
        {
            StartCoroutine(spawnTimer());
            spawnYet = "w";
        }
    }

    void ReplaceFruit()
    {
        if (newFruit == "y")
        {
            newFruit = "n";
            //spawnYet = "n";
            Instantiate(fruitObj[witchFruit + 1], spawnPos, fruitObj[0].rotation);
        }
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.75f);
        Instantiate(fruitObj[Random.Range(0, 3)], transform.position, fruitObj[0].rotation);
        spawnYet = "y";
    }
}
