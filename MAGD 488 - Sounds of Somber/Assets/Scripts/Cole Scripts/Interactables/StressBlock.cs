using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBlock : MonoBehaviour
{
    private PlayerHealth health;
    private AudioManager myAudioManager;
    private MoveBlockManager myBlockManager;
    private bool hurtPlayer = true;
    private bool inRange = false;
    public float stressIncreaseNum = 5f;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>();
        FindBlockManager();
        FindAudioManager(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            if (hurtPlayer == true)
            {
                hurtPlayer = false;
                //put a variable for number because I'm using it in a context where it needs to be high
                health.IncreaseStress(stressIncreaseNum);
                StartCoroutine(HitCoolDown());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            inRange = true;
            myAudioManager.Play("PlayerBreathing"); 
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainPlayer"))
        {
            inRange = false;
            if (myBlockManager.currentBlock != gameObject)
            {
                myAudioManager.StopSound("PlayerBreathing");
            }

        }

    }

    private IEnumerator HitCoolDown()
    {
        yield return new WaitForSeconds(2f);
        hurtPlayer = true;
    }

    void FindBlockManager()
    {
        //Debug.Log("FIND BLOCK MANAGER"); 

        while (myBlockManager == null)
        {
            myBlockManager = GameObject.FindObjectOfType<MoveBlockManager>().GetComponent<MoveBlockManager>();
        }
    }

    void FindAudioManager()
    {
        while (myAudioManager == null)
        {
            myAudioManager = GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
            Debug.Log("Audio manager null");
        }

        //incase breathing still playing
        myAudioManager.StopSound("PlayerBreathing");
    }

    public void StopStressSound()
    {
        //incase breathing still playing
        myAudioManager.StopSound("PlayerBreathing");
    }
}
