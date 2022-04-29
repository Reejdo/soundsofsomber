using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentBlock;
    public GameObject moveIconUI; 

    void Start()
    {
        moveIconUI.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBlock == null)
        {
            moveIconUI.SetActive(false);
        }
        else
        {
            moveIconUI.SetActive(true);
        }
    }
}
