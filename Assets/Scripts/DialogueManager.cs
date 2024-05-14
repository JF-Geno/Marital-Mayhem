using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<DialogueLine> sentences = new Queue<DialogueLine>();
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Starting converstaion");
        sentences.Clear();

        foreach (DialogueLine sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine sentence = sentences.Dequeue();
        Debug.Log(sentence.name + ": " + sentence.text);
        Invoke("DisplayNextSentence", 3);
    }
    public void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}