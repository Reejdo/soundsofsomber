using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressCloud : MonoBehaviour
{
	private PlayerHealth health;
    private bool hurtPlayer = true;
    private bool inCloud = false;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(inCloud){
        	if(hurtPlayer == true){
        		hurtPlayer = false;
        		health.IncreaseStress(5); 
        		StartCoroutine(HitCoolDown());
        	}
        }
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("Player")){
            inCloud = true;
        }
    	
    }

    void OnTriggerExit2D(Collider2D other){
    	if(other.CompareTag("Player")){
            inCloud = false;
        }
    	
    }

    private IEnumerator HitCoolDown(){
    	yield return new WaitForSeconds(2f);
    	hurtPlayer = true;
    }
}
