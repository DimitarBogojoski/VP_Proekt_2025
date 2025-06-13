using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform[] fruitObj;
    static public bool spawnYet = false;
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    static public bool newFruit=false;
    static public int witchFruit=0;

    void Start()
    {
        SpawnFruitImmediate();
    }

    void Update()
    {
        

        if (Input.GetKey("a")){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }
        if(Input.GetKey("d")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2,0);
        }
        if((!Input.GetKey("a")) && (!Input.GetKey("d"))){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

        if (transform.position.x < -2.55f)
            transform.position = new Vector2(-2.55f, transform.position.y);
        if (transform.position.x > 1.65f)
            transform.position = new Vector2(1.65f, transform.position.y);

        cloudxPos = transform.position;

        if (Input.GetKeyDown("space") && spawnYet ) {
            spawnYet = false;
            StartCoroutine(spawnTimer());
        }

        ReplaceFruit();
    }

    void SpawnFruitImmediate()
    {
        GameObject fruit = Instantiate(fruitObj[Random.Range(0, 3)], transform.position, fruitObj[0].rotation).gameObject;
        fruit.GetComponent<Fruit_con>().followCloud = true;
        spawnYet = true;
    }

    void ReplaceFruit()
    {
        if (newFruit)
        {
            newFruit = false;
            GameObject fruit = Instantiate(fruitObj[witchFruit + 1], spawnPos, fruitObj[0].rotation).gameObject;
            fruit.GetComponent<Fruit_con>().followCloud = false;
            fruit.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.75f);
        SpawnFruitImmediate();
    }

}
