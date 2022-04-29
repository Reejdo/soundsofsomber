using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEntities : MonoBehaviour
{
	public GameObject[] despawnSelect;

    // Start is called before the first frame update
    void Start()
    {
    	if(despawnSelect.Length == 0){
    		Destroy(this);
    	}
        
        /*for(int i = 0; i < spawnSelect.Length; i++){ //makes everything in its array invisible
    			spawnSelect[i].SetActive(false);
    	}*/
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("MainPlayer")){
    		for(int i = 0; i < despawnSelect.Length; i++){ //spawns everything in its array
    			if(despawnSelect[i] != null)
    				despawnSelect[i].SetActive(false);
    		}
    		Destroy(this);
    	}
    	
    	
    }
}
