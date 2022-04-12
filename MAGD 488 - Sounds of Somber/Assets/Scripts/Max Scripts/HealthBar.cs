using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider; //health = stress
	private float curHealth;
	public GameObject screenDark;

	void Start(){
		curHealth = slider.value;
	}


	void Update(){
		curHealth = slider.value;

		if(curHealth >= 60){
			screenDark.SetActive(true);
		}
		else{
			screenDark.SetActive(false);
		}
	}

	public void SetMinHealth(float stress){ //sets the stress to 0 at the beginning of each level
		slider.minValue = stress;
		slider.value = stress;
	}

   	public void SetHealth(float stress){ //updates the stress meter when it increases/decreases
   		slider.value = stress;
   	}
}
