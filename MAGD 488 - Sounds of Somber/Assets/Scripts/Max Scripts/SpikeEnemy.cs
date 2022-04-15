using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
	public float dmg = 25;
	private bool hit = false;
	private AudioSource audio;
    private CamShake shake;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        shake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<CamShake>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player") && hit == false){
    		hit = true;
            StartCoroutine(Hurting());
    	}
    }

    public IEnumerator Hurting(){
        shake.Shake();
        audio.Play();
        health.IncreaseStress(dmg);
        //this.spriteRen.enabled = false;
        //this.GetComponent<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(1f);
        hit = false;
        //Destroy(gameObject);
    }
}
