using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public float minHealth = 0; //health = stress.
	public float maxHealth = 100;
	public float currentHealth;
	private AudioSource audi;
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
    	audi = gameObject.GetComponent<AudioSource>();
    	audi.dopplerLevel = 0f;
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
                if (currentHealth < 0)
                {
                    currentHealth = 0; 
                }
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
    		audi.Stop();
    	}
    }

    


   //increases stress when struck by hazard
	public void IncreaseStress(float stress){
		calm = false;
		cooldown = 3f;
    	currentHealth += stress;

    	//Debug.Log("Damage Dealt");
    	healthBar.SetHealth(currentHealth);
    	//StartCoroutine(CalmCooldown());
    	if(currentHealth >= 100){
    		currentHealth = 100;
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    	}
    }
    
    

}
