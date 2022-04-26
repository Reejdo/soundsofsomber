using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    public int counter = 0;
    public int itemCount;
    public GameObject[] objectsToDisable;
    public bool objectDisabled = false;
    public float timeToDiable;
    private Animator myAnim;
    private AudioManager myAudioManager; 

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAudioManager = GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("disable", objectDisabled); 

       if (counter >= itemCount && !objectDisabled)
        {
            objectDisabled = true;
            StartCoroutine(DisableObject()); 
        } 
    }

    IEnumerator DisableObject()
    {
        myAudioManager.Play("PuzzleSolve"); 
        yield return new WaitForSeconds(timeToDiable);
        SetObjectStates(false); 
    }

    void SetObjectStates(bool state)
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(state);
        }
    }

}
