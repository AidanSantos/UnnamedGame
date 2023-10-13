using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class NPC : MonoBehaviour
{
    [Header("NPC Information")]
    [SerializeField] private string npcName;
    [SerializeField] private string[] dialogue;

    private bool playerIsClose;
    private DialogueController dialogueController;

    void Start()
    {
        dialogueController = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<DialogueController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialogueController.dialoguePanel.activeInHierarchy)
            {
                // Ensure that the coroutine is running before attempting to skip
                if (dialogueController.typingRoutine != null)
                {
                    StopCoroutine(dialogueController.typingRoutine); // Stop the typing coroutine
                }

                dialogueController.dialogueText.text = dialogue[dialogueController.index]; // Set text instantly
                dialogueController.dialogueButton.SetActive(true);
                dialogueController.skipButton.SetActive(false);
            }
            else
            {
                StartDialogue();
            }
        }
    }

    private void StartDialogue()
    {
        dialogueController.dialoguePanel.SetActive(true);
        dialogueController.currentDialogue = dialogue;
        dialogueController.nameText.text = npcName;
        dialogueController.typingRoutine = StartCoroutine(dialogueController.Typing());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            dialogueController.ZeroText();
        }
    }
}