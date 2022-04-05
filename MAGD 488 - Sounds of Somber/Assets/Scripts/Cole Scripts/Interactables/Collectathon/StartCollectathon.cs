using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollectathon : MonoBehaviour
{
    private bool collectathonStarted;
    [SerializeField]
    private float collectathonTime;
    [SerializeField]
    private GameObject[] coinsToCollect;
    [SerializeField]
    private DisappearingBlock myDisappearingBlock; 

    // Start is called before the first frame update
    void Start()
    {
        SetCoinState(false);
        myDisappearingBlock = GameObject.Find("DoorToDisable").GetComponent<DisappearingBlock>();
        myDisappearingBlock.itemCount = coinsToCollect.Length; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectathonStart()
    {
        if (!collectathonStarted && !myDisappearingBlock.objectDisabled)
        {
            collectathonStarted = true;
            StartCoroutine(Collectathon()); 
        }
    }

    IEnumerator Collectathon()
    {
        SetCoinState(true);
        yield return new WaitForSeconds(collectathonTime);
        myDisappearingBlock.counter = 0; 
        SetCoinState(false);
        collectathonStarted = false; 
    }

    void SetCoinState(bool state)
    {
        foreach (GameObject obj in coinsToCollect)
        {
            obj.SetActive(state); 
        }
    }
}
