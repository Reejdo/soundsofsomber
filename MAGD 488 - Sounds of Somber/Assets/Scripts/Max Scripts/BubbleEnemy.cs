using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEnemy : MonoBehaviour
{

	private float timeBtwshots;
	public float startTimeBtwShots;
	public Transform shootPoint;
	public GameObject projectile;
	

    // Start is called before the first frame update
    void Start()
    {
        timeBtwshots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
    	if(timeBtwshots <= 0){
    		Instantiate(projectile, shootPoint.position, Quaternion.identity);
    		timeBtwshots = startTimeBtwShots;
    	} else{
    		timeBtwshots -= Time.deltaTime;
    	}
    }

    void OnTriggerEnter2D (Collider2D other){
    	if(other.gameObject.CompareTag("MainPlayer"))
    		DesDeath();
    }

    public void DesDeath(){
        timeBtwshots = 10f;
        gameObject.GetComponent<Animator>().SetTrigger("death");
        Destroy(gameObject, 2);
    }
}
