using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5;
    private Transform target;
    private PlayerHealth health;
    private bool hit = false;
    private SpriteRenderer spriteRen;
    public float enemyPosX;
	public float playerPosX;

    void Start()
    {
    	health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        enemyPosX = this.transform.position.x;
    	playerPosX = target.transform.position.x;
        if(playerPosX <= enemyPosX)
    		spriteRen.flipX = false;
    	else if(playerPosX > enemyPosX)
    		spriteRen.flipX = true;
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player") && hit == false){
    		hit = true;
    		health.IncreaseStress(30);
    		Destroy(gameObject);
    	}
    	
    }
}
