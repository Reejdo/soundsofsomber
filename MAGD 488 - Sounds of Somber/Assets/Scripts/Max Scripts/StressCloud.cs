using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressCloud : MonoBehaviour
{
	private PlayerHealth health;
    private bool hurtPlayer = true;
    private bool inCloud = false;
    public float stressIncreaseNum = 5f; 
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
                //put a variable for number because I'm using it in a context where it needs to be high
        		health.IncreaseStress(stressIncreaseNum); 
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
