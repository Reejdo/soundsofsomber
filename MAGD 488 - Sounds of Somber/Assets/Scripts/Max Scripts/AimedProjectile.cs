using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private GameObject target;
    private Vector2 moveDir;
    private PlayerHealth health;
    private bool hit = false;

    private ParticleSystem emis;
    private SpriteRenderer spriteRen;
    private AudioSource audi;
    private CamShake shake;
   

    void Start(){

        health = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>();
        emis = gameObject.GetComponent<ParticleSystem>();
    	rb = GetComponent<Rigidbody2D>();
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
    	target = GameObject.FindGameObjectWithTag("MainPlayer");
    	moveDir = (target.transform.position - transform.position).normalized * speed;
        shake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<CamShake>();
        audi = gameObject.GetComponent<AudioSource>();
    	rb.velocity = new Vector2(moveDir.x, moveDir.y);
    	Destroy(gameObject, 8.5f);
    }


    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("MainPlayer") && hit == false){
            hit = true;
            //health.IncreaseStress(20);
            StartCoroutine(Hit());
            //Destroy(gameObject);
        }
    	
    }


    public IEnumerator Hit(){
        shake.Shake();
        audi.Play();
        health.IncreaseStress(30);
        this.spriteRen.enabled = false;
        emis.Stop();
        yield return new WaitForSeconds(audi.clip.length);
        Destroy(gameObject);
    }

}
