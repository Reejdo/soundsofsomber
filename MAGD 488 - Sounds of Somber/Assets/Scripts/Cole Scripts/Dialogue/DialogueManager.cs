using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    //public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;
    private Queue<Sprite> portraits;
    [SerializeField] private GameObject[] UIElements;
    public bool talking;
    //private LevelManager lvlManage;


    void Start()
    {
        //lvlManage = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        talking = false;
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        foreach (GameObject obj in UIElements)
        {
            obj.SetActive(false);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        /* Eventually, make it so player can't move
        if (lvlManage.playerBeginner)
        {
            UncloakedMovement ucMove = GameObject.FindGameObjectWithTag("Player").GetComponent<UncloakedMovement>();
            ucMove.canMove = false;
        }
        else
        {
            PlayerMovement plrMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            plrMove.canMove = false;
        }
        */ 

        Debug.Log("Starting conversation");
        talking = true;

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

        talking = false;

        /* Eventually, make it so player can move
        if (lvlManage.playerBeginner)
        {
            UncloakedMovement ucMove = GameObject.FindGameObjectWithTag("Player").GetComponent<UncloakedMovement>();
            ucMove.canMove = true;
        }
        else
        {
            PlayerMovement plrMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            plrMove.canMove = true;
        }
        */

        Debug.Log("End of Conversation"); 
    }

}
