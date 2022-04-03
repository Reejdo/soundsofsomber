using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public DisappearingBlock myDisappearingBlock;
    // Start is called before the first frame update
    void Start()
    {
        myDisappearingBlock = GameObject.Find("DoorToDisable").GetComponent<DisappearingBlock>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            myDisappearingBlock.counter += 1;
            gameObject.SetActive(false); 
        }
    }
}
