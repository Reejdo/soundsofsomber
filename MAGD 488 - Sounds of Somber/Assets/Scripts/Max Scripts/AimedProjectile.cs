using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb;
    private GameObject target;
    private Vector2 moveDir;
   

    void Start(){
    	rb = GetComponent<Rigidbody2D>();
    	target = GameObject.FindGameObjectWithTag("Player");
    	moveDir = (target.transform.position - transform.position).normalized * speed;
    	rb.velocity = new Vector2(moveDir.x, moveDir.y);
    	Destroy(gameObject, 8f);
    }


    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player")){
    		DestroyProjectile();
    	}
    	
    }

    void DestroyProjectile(){
    	Destroy(gameObject);
    }

}
