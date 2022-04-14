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
	private float cooldown = 3f;
	private float destressTimer = 2f;
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

    	//lower stress over time if no dmg taken
    	if (calm){
    		destressTimer -= 1 * Time.deltaTime;
    		if(destressTimer <= 0){
    			currentHealth -= 5;
    			destressTimer = 1.5f;
    		}

    		healthBar.SetHealth(currentHealth);
    	}
    	else if(!calm){
    		cooldown -= 1 * Time.deltaTime;
    		if(cooldown <= 0)
    			calm = true;
    	}

    	if (currentHealth >= 60 && currentHealth <= 100){
    		//audio.clip = sfx[0];
    		//if(!audio.isPlaying)
    			//audio.PlayOneShot(audio.clip, 0.2f);
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


   //increases stress when struck by hazard
	public void IncreaseStress(float stress){
		//StopCoroutine(CalmCooldown());
		//audio.clip = sfx[1];
		//audio.PlayOneShot(audio.clip, 0.5f);
		//audio.clip = sfx[0];
		calm = false;
		cooldown = 3f;
    	currentHealth += stress;
    	Debug.Log("Damage Dealt");
    	healthBar.SetHealth(currentHealth);
    	//StartCoroutine(CalmCooldown());
    	if(currentHealth >= 100){
    		currentHealth = 100;
    		Application.LoadLevel(Application.loadedLevel);
    	}
    }
    
     //still not quite working how I want it too.
    /*public void DecreaseStress(){
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
    }*/

}
