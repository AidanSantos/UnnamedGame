using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class DialogueController : MonoBehaviour
{

    [Header ("Dependancies")]
    public GameObject dialoguePanel; 
    public TextMeshProUGUI dialogueText; 
    public TextMeshProUGUI nameText;
    public GameObject dialogueButton; 
    public GameObject skipButton; 

    [Header ("Settings")]
    [SerializeField] private float wordSpeed;

    [Header ("Runtime Public Vars")]
    public int index = 0;  
    public string[] currentDialogue;
    public Coroutine typingRoutine; 

    void Awake()
    {
        dialogueButton.GetComponent<Button>().onClick.AddListener(Nextline);
    }


    public void Nextline()
    {
        dialogueButton.SetActive(false);
        skipButton.SetActive(true);

        if (index < currentDialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";

            // Check if the coroutine is not already running
            if (typingRoutine == null)
            {
                typingRoutine = StartCoroutine(Typing());
            }
        }
        else
        {
            ZeroText();
        }
    }

    public void SkipText()
    {
        dialogueText.text = currentDialogue[index];

        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null; // Set to null after stopping
        }
    }

    public IEnumerator Typing()
    {
        foreach(char letter in currentDialogue[index].ToCharArray())
        {
            dialogueText.text += letter; 
            yield return new WaitForSeconds(wordSpeed); 
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0; 
        dialoguePanel.SetActive(false);
    }
}
