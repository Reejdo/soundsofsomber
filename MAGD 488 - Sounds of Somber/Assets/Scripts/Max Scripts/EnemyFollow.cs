using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float dmg;
    public float speed = 5;
    private Transform target;
    private PlayerHealth health;
    private bool hit = false;
    private ParticleSystem emis;
    private SpriteRenderer spriteRen;
    private float enemyPosX;
	private float playerPosX;
    private float originalSpeed;
    private float distance;
    
    //for hit

    private AudioSource audi;
    private CamShake shake;

    void Start()
    {
        emis = gameObject.GetComponent<ParticleSystem>();
    	health = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>();
        target = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Transform>();
        shake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<CamShake>();
        audi = gameObject.GetComponent<AudioSource>();
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        originalSpeed = speed;
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

        distance = playerPosX - enemyPosX;

        if(distance >= 25)
            speed = 0;
        else
            speed = originalSpeed;
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("MainPlayer") && hit == false){
    		hit = true;
            StartCoroutine(Hit());
    	}
    	
    }

    public IEnumerator Hit(){
        

        shake.Shake();
        audi.Play();
        health.IncreaseStress(dmg);
        this.spriteRen.enabled = false;
        emis.Stop();
        yield return new WaitForSeconds(audi.clip.length);
        Destroy(gameObject);
    }
}
