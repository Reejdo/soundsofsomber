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

    private SpriteRenderer spriteRen;
    private AudioSource audio;
    private CamShake shake;
   

    void Start(){

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    	rb = GetComponent<Rigidbody2D>();
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
    	target = GameObject.FindGameObjectWithTag("Player");
    	moveDir = (target.transform.position - transform.position).normalized * speed;
        shake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<CamShake>();
        audio = gameObject.GetComponent<AudioSource>();
    	rb.velocity = new Vector2(moveDir.x, moveDir.y);
    	Destroy(gameObject, 8.5f);
    }


    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player") && hit == false){
            hit = true;
            //health.IncreaseStress(20);
            StartCoroutine(Hit());
            //Destroy(gameObject);
        }
    	
    }


    public IEnumerator Hit(){
        shake.Shake();
        audio.Play();
        health.IncreaseStress(30);
        this.spriteRen.enabled = false;
        this.GetComponent<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(gameObject);
    }

}
