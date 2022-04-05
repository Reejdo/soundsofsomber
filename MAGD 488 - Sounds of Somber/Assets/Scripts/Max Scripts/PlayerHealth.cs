using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public float minHealth = 0; //health = stress.
	public float maxHealth = 100;
	public float currentHealth;
	private AudioSource audio;
	public HealthBar healthBar;
	public AudioClip[] sfx = new AudioClip[1];
	private bool calm = true;
	//private BoxCollider2D hitbox;
	//private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
    	if(healthBar == null)
    		this.enabled = false;
    	audio = gameObject.GetComponent<AudioSource>();
    	audio.dopplerLevel = 0f;
    	calm = true;
        currentHealth = minHealth;
        healthBar.SetMinHealth(minHealth);
    }

    void Update(){

    	if (calm){
    		calm = false;
    		DecreaseStress();
    	}

    	if (currentHealth >= 50 && currentHealth <= 100){
    		audio.clip = sfx[0];
    		if(!audio.isPlaying)
    			audio.PlayOneShot(audio.clip, 0.1f);
    	}
    	else{
    		audio.Stop();
    	}
    }

    /*void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Hurt")){
    		hit = false;
    		/*if (calm == true){
    			StartCoroutine(CalmCooldown(5));
    		}
    	}
	
    }*/


   
	public void IncreaseStress(float stress){
		StopCoroutine(CalmCooldown());
    	currentHealth += stress;
    	calm = false;
    	Debug.Log("Damage Dealt");
    	healthBar.SetHealth(currentHealth);
    	StartCoroutine(CalmCooldown());
    	if(currentHealth >= 100){
    		currentHealth = 100;
    		Application.LoadLevel(Application.loadedLevel);
    	}
    }
    
     //still not quite working how I want it too.
    public void DecreaseStress(){
    	currentHealth -= 5;
    	healthBar.SetHealth(currentHealth);
    	if(currentHealth <= 0)
    		currentHealth = 0;
    	calm = false;
    	StartCoroutine(CalmCooldown());
    }

    public IEnumerator CalmCooldown(){
    	yield return new WaitForSeconds(3f);
    	calm = true;
    }




}
