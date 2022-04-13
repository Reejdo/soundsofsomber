using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    public int pageCount;
    public int maxPageNumber;
    [SerializeField] private GameObject diaryBookUI, diaryPageUI;
    [SerializeField] private GameObject[] diaryPages; 
    [SerializeField] private GameObject[] pageButtons;
    [SerializeField] private GameObject[] clickablePages; 
    [SerializeField] private bool[] pageStates;
    private bool enabledLastPage = false;
    private DialogueManager myDialogueManager;
    private DataManager myDataManager; 

    // Start is called before the first frame update
    void Start()
    {
        myDialogueManager = GameObject.FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        myDataManager = GameObject.FindObjectOfType<DataManager>().GetComponent<DataManager>();

        for (int i = 0; i < maxPageNumber; i++)
        {
            pageStates[i] = myDataManager.diaryStates[i]; 
        }


        if (pageCount == maxPageNumber)
        {
            diaryPages[maxPageNumber - 1].SetActive(true);
            enabledLastPage = true; 
        }
        else
        {
            diaryPages[maxPageNumber - 1].SetActive(false);
            enabledLastPage = false;
        }


        diaryBookUI.SetActive(false);
        diaryPageUI.SetActive(false);
        SetPageStates(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (pageCount == maxPageNumber && !enabledLastPage)
        {
            enabledLastPage = true;
            diaryPages[maxPageNumber - 1].SetActive(true);
        }
    }

    void SetPageStates()
    {
        for (int i = 0; i < maxPageNumber; i++)
        {
            clickablePages[i].SetActive(false); 

            if (pageStates[i] == true)
            {
                pageButtons[i].SetActive(true);
            }
            else
            {
                pageButtons[i].SetActive(false); 
            }
        }
    }

    void DisablePageButtons()
    {
        for (int i = 0; i < maxPageNumber; i++)
        {
            pageButtons[i].SetActive(false); 
        }
    }

    public void UpdateDiaryPage(string name)
    {
        for (int i = 0; i < maxPageNumber; i++)
        {
            if (diaryPages[i].gameObject.name == name)
            {
                pageCount++; 
                pageStates[i] = true;
                pageButtons[i].SetActive(true);
                break; 
            }
        }

        for (int i = 0; i < maxPageNumber; i++)
        {
            myDataManager.diaryStates[i] = pageStates[i];
            Debug.Log("Updating data manager");
        }
    }

    public void ClickBookButton()
    {
        if (!myDialogueManager.talking)
        {
            if (diaryBookUI.activeSelf)
            {
                diaryBookUI.SetActive(false);
                diaryPageUI.SetActive(false);
            }
            else
            {
                diaryBookUI.SetActive(true);
                diaryPageUI.SetActive(true);
            }
        }
    }

    public void ClickPageButton(int diaryNumber)
    {
        Debug.Log(clickablePages[diaryNumber - 1].name); 
        if (clickablePages[diaryNumber - 1].activeSelf)
        {
            clickablePages[diaryNumber - 1].SetActive(false);
            SetPageStates(); 
        }
        else
        {
            clickablePages[diaryNumber - 1].SetActive(true);
            DisablePageButtons(); 
        }
    }
}
