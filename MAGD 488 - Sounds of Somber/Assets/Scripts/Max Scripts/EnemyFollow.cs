using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5;
    private Transform target;
    private PlayerHealth health;

    void Start()
    {
    	health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player")){
    		health.IncreaseStress(30);
    		Destroy(gameObject);
    	}
    	
    }
}
