using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ReactionDialogue : MonoBehaviour
{
    public List<string> lines;

    public float textSpeed = 0.15f;
    public float autoSpeed = 1.5f;
    private int index;

    public bool isTalking = false;

    public TextMeshProUGUI textComponent;
    [SerializeField]
    private GameObject dialogueObject; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueObject.SetActive(false); 
        textComponent.text = string.Empty; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(List<string> linesToSet)
    {
        lines.Clear();
        textComponent.text = string.Empty; 

        index = 0;

        Debug.Log(linesToSet.Count); 

        for (int i = 0; i < linesToSet.Count; i++)
        {
            lines.Add(linesToSet[i]); 
        }

        dialogueObject.SetActive(true);

        if (!isTalking)
        {
            isTalking = true; 
            StartCoroutine(TypeLine());
        }

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }

        //wait to start next line
        yield return new WaitForSeconds(autoSpeed);
        NextLine(); 
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine()); 
        }
        else
        {
            lines.Clear();
            textComponent.text = string.Empty; 
            isTalking = false; 
            dialogueObject.SetActive(false); 
        }
    }

    public void ClearDialogueForNew()
    {
        isTalking = false;
        lines.Clear();
        textComponent.text = string.Empty;
        Debug.Log("Clear dialogue"); 
    }

    public void QueueAnotherDialogue(List<string> linesToSet)
    {

        int originalLength = lines.Count;
        int fullLength = lines.Count + linesToSet.Count; 

        for (int i = originalLength - 1; i < fullLength; i++)
        {
            lines.Add(linesToSet[i]);
            Debug.Log("Added line"); 
        }
    }

}
