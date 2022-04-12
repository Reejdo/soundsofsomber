using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene : MonoBehaviour
{
    public UnityEvent LoadScene;

    public float timeBetweenImages;
    public GameObject[] myImages;
    private LoadScene myLoadScene;
    // Start is called before the first frame update

    private void Awake()
    {
        myLoadScene = GetComponent<LoadScene>();
    }

    void Start()
    {
        DisableImages();
        StartCoroutine(StartCutScene()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisableImages()
    {
        foreach (GameObject obj in myImages)
        {
            obj.SetActive(false); 
        }
    }

    void CallLoadScene()
    {
        LoadScene.Invoke();
    }

    IEnumerator StartCutScene()
    {
        Debug.Log("StartCutScene"); 
        for (int i = 0; i < myImages.Length; i++)
        {
            myImages[i].SetActive(true);
            yield return new WaitForSeconds(timeBetweenImages);
            myImages[i].SetActive(false); 
        }

        CallLoadScene();
    }
}
