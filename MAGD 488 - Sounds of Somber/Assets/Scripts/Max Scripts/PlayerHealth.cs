using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public float minHealth = 0; //health = stress.
	public float maxHealth = 100;
	public float currentHealth;

	public HealthBar healthBar;

	private bool calm;
	//private BoxCollider2D hitbox;
	private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
    	if(healthBar == null)
    		this.enabled = false;
    	//hitbox = GetComponent<BoxCollider2D>();
    	calm = true;
        currentHealth = minHealth;
        healthBar.SetMinHealth(minHealth);
    }

    void Update(){
    	
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Hurt")){
    		
    		
    		hit = false;
    		if (calm == true){
    			StartCoroutine(CalmCooldown(5));
    		}
    	}

    	
    }


    //this still needs some work...
    public void IncreaseStress(float stress){
    	currentHealth += stress;
    	Debug.Log("Damage Dealt");
    	healthBar.SetHealth(currentHealth);
    	if(currentHealth >= 100)
    		currentHealth = 100;
    }

    public void DecreaseStress(float stress){
    	currentHealth -= stress;
    	healthBar.SetHealth(currentHealth);
    	if(currentHealth <= 0)
    		calm = false;
    }

    private IEnumerator CalmCooldown(float waiting){
    	calm = false;
    	yield return new WaitForSeconds(waiting);
    	calm = true;

    	while(calm == true){
    		yield return new WaitForSeconds(1f);
    		DecreaseStress(5);
    	}
    }




}
