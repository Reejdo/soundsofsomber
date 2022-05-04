using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StartCollectathon : MonoBehaviour
{
    private bool collectathonStarted;
    [SerializeField]
    private int collectathonTime = 15;
    [SerializeField]
    private GameObject[] coinsToCollect;
    [SerializeField]
    private DisappearingBlock myDisappearingBlock;
    public TMP_Text myTimerText;
    public GameObject timerUI; 

    // Start is called before the first frame update
    void Start()
    {
        timerUI.SetActive(false); 
        SetCoinState(false);
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
        timerUI.SetActive(true); 
        SetCoinState(true);
        for (int i = collectathonTime; i > 0; i--)
        {
            myTimerText.text = i + " s"; 
            yield return new WaitForSeconds(1f);
        }

        timerUI.SetActive(false);
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
