using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    float speed = 2f;
    float stoppingDistance = 1f;
    Transform target;
    public Collider2D collArea;
    bool follow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance && follow){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("entering");

        if(collision.gameObject.tag == "Player"){
            Debug.Log("entering");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player"){
            follow = true;
        }

        if(col.tag == "Exit"){
            follow = false;
            Destroy(this.gameObject);
        }
    }
}
