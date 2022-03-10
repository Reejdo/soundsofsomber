using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    float currentTime = 0f;
    public float startTime = 10f;

    public TextMeshProUGUI timeText;

    void Start(){
    	currentTime = startTime;
    }

    void Update(){
    	
    	currentTime -= 1 * Time.deltaTime;
    	timeText.text = currentTime.ToString("0");
    	
    	if (currentTime <= 0){
    		currentTime = 0;
    	}

    }
}
