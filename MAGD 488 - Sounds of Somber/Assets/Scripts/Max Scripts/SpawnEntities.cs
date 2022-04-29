using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
	public GameObject[] spawnSelect;

    // Start is called before the first frame update
    void Start()
    {
    	if(spawnSelect.Length == 0){
    		Destroy(this);
    	}
        
        for(int i = 0; i < spawnSelect.Length; i++){ //makes everything in its array invisible
    			spawnSelect[i].SetActive(false);
    	}
    }

    void OnTriggerEnter2D(Collider2D other){
    	if(other.CompareTag("MainPlayer")){
    		for(int i = 0; i < spawnSelect.Length; i++){ //spawns everything in its array
    			spawnSelect[i].SetActive(true);
    		}
    		Destroy(this);
    	}
    	
    	
    }
}
