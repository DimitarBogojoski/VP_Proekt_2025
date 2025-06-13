using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_con : MonoBehaviour
{
    private bool InTheCloud = true;
    private bool OutTheCloud = false;
    public bool followCloud=true;
    void Start()
    {
           // GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<SpriteRenderer>().enabled = true;

    }

    void Update()
    {
        if(followCloud)
        {
            GetComponent<Transform>().position = Cloud.cloudxPos;
        }

        if (Input.GetKeyDown("space") && InTheCloud ) 
        {
            InTheCloud = false;
            followCloud = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            StartCoroutine(CheckGameOver());
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag && gameObject.tag != "6")
        {
            Cloud.spawnPos = transform.position;
            Cloud.newFruit = true;
            Cloud.witchFruit = int.Parse(gameObject.tag);

            
            int tagValue = int.Parse(gameObject.tag);
            ScoreManager.instance.AddToScore(tagValue+1);

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == "limit") && OutTheCloud)
        {
            Debug.Log("Game Over!");
            FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }

    IEnumerator CheckGameOver()
    {
        yield return new WaitForSeconds(.75f);
        OutTheCloud = true;
    }
}
