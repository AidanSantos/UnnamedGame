using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DialogueChain
{
    [TextArea(3, 10)]
    public string[] dialogue;
}

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public AudioSource audioSource;
    public AudioClip[] letterSounds;

    private DialogueChain currentDialogueChain;
    private int currentChainIndex;
    private int currentIndex;

    // Start the dialogue with the provided chain
    public void StartDialogue(DialogueChain dialogueChain)
    {
        currentDialogueChain = dialogueChain;
        currentChainIndex = 0;
        currentIndex = 0;

        StartCoroutine(DisplayTextWithSounds());
    }

    // Coroutine to display text with randomized sounds
    private IEnumerator DisplayTextWithSounds()
    {
        while (currentChainIndex < currentDialogueChain.dialogue.Length)
        {
            string currentLine = currentDialogueChain.dialogue[currentChainIndex];

            while (currentIndex < currentLine.Length)
            {
                char currentChar = currentLine[currentIndex];
                dialogueText.text += currentChar;

                // Play a randomized letter sound
                PlayRandomLetterSound();

                // Delay for a short time before showing the next character
                yield return new WaitForSeconds(0.1f);

                currentIndex++;
            }

            // Move to the next line in the chain
            currentChainIndex++;
            currentIndex = 0;

            // Clear the text for the next line
            dialogueText.text = "";

            // Pause before starting the next line
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Play a randomized letter sound
    private void PlayRandomLetterSound()
    {
        if (letterSounds.Length > 0)
        {
            AudioClip soundToPlay = letterSounds[Random.Range(0, letterSounds.Length)];
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }
    }
}
