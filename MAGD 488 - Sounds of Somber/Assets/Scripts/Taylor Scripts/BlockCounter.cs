using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    public DisappearingBlock myDisappearingBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("hit");

        if (collision.gameObject.CompareTag("MoveBlock"))
        {
            myDisappearingBlock.counter += 1;
        }
    }
}
