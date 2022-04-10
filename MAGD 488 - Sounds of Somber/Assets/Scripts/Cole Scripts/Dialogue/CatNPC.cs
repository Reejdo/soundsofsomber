using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNPC : MonoBehaviour
{
    [SerializeField] private float animTime;
    private Animator myAnim;
    private bool playerInRange = false;
    private bool catAnimStart = false; 

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("playerInRange", playerInRange); 


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            if (!catAnimStart)
            {
                StartCoroutine(DestroyCat());
            }

        }
    }

    IEnumerator DestroyCat()
    {
        catAnimStart = true;
        yield return new WaitForSeconds(animTime);
        Destroy(gameObject); 
    }
}
