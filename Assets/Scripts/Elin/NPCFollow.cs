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
    IndicatorsController indicators;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        indicators = GameObject.Find("Indicators").GetComponentInChildren<IndicatorsController>();
    }

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
            indicators.civUpdate++;
            Destroy(this.gameObject);
        }
    }
}
