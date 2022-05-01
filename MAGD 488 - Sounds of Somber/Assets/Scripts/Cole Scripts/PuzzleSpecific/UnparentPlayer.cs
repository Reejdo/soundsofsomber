using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentPlayer : MonoBehaviour
{
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            Debug.Log("NULL"); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MainPlayer"))
        {
            Debug.Log("Unparent"); 
            playerObject.transform.SetParent(null);
        }
    }
}
