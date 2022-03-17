using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    //public TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    public Queue<string> sentences;
    //private Queue<Sprite> portraits;
    [SerializeField] private List<GameObject> UIElements;
    public bool talking;
    private PlayerControl myPlayerControl; 

    //private LevelManager lvlManage;


    void Start()
    {
        //lvlManage = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        talking = false;
        sentences = new Queue<string>();
        //portraits = new Queue<Sprite>();

        myPlayerControl = GameObject.FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>(); 

        /*
        foreach (GameObject obj in UIElements)
        {
            obj.SetActive(false);
        }
        */ 
    }

    public void StartDialogue(Dialogue dialogue, List<GameObject> newUIElements, TMP_Text newDialogueText)
    {
        myPlayerControl.canMove = false; 

        //Debug.Log("Starting conversation");
        talking = true;

        for (int i = 0; i < newUIElements.Count; i++)
        {
            UIElements.Add(newUIElements[i]);
        }

        dialogueText = newDialogueText; 

        foreach (GameObject obj in UIElements)
        {
            obj.SetActive(true);
        }

        //nameText.text = dialogue.name; If we wanted names

        sentences.Clear();

        //this queues each sentence in
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        /* If we wanted portraits 
        foreach (Sprite img in dialogue.portraits)
        {
            portraits.Enqueue(img);
        }
        */

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("sentence count: " + sentences.Count); 

        //if there are no more sentences
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //Sprite portrait = portraits.Dequeue();

        //UIElements[0].GetComponent<Image>().sprite = portrait;

        dialogueText.text = sentence;

        //Debug.Log(sentence); 
    }

    public void EndDialogue()
    {
        foreach (GameObject obj in UIElements)
        {
            obj.SetActive(false);
        }

        UIElements.Clear();

        talking = false;

        myPlayerControl.canMove = true;

    }

}
