using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ReactionDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public List<string> lines;

    public float textSpeed = 0.15f;
    public float autoSpeed = 1.5f;
    private int index;

    private bool isTalking = false; 

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
        index = 0;

        Debug.Log(linesToSet.Count); 

        for (int i = 1; i < linesToSet.Count; i++)
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
            isTalking = false; 
            dialogueObject.SetActive(false); 
        }
    }

}
