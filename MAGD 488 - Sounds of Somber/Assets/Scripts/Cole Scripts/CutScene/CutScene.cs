using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class CutScene : MonoBehaviour
{
    public UnityEvent LoadScene;

    public float timeBetweenImages, timeAfterLastImage = 2f;
    public GameObject[] myImages;
    public Image myFader; 
    private LoadScene myLoadScene;
    private DataManager myDataManager; 
    // Start is called before the first frame update

    private void Awake()
    {
        myLoadScene = GetComponent<LoadScene>();
        myFader = myFader.gameObject.GetComponent<Image>();
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>(); 
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

    IEnumerator FadeOut(float fadeTime)
    {
        float elapsedTime = 0.0f;
        Color c = myFader.color;
        while (elapsedTime < fadeTime)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            myFader.color = c;
        }
    }

    IEnumerator FadeIn(float fadeTime)
    {
        float elapsedTime = 0.0f;
        Color c = myFader.color;
        while (elapsedTime < fadeTime)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            myFader.color = c;
        }
    }

        IEnumerator StartCutScene()
    {
        Debug.Log("StartCutScene"); 
        for (int i = 0; i < myImages.Length; i++)
        {
            StartCoroutine(FadeOut(1f)); 
            myImages[i].SetActive(true);
            yield return new WaitForSeconds(timeBetweenImages);
            StartCoroutine(FadeIn(1f));
            myImages[i].SetActive(false); 
        }

        yield return new WaitForSeconds(timeAfterLastImage);

        //need to update in case it's above 0 if we were going directly into a chapter
        myDataManager.lastCheckpoint = 0; 

        CallLoadScene();
    }
}
