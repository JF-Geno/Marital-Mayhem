using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Starting converstaion with {dialogue.name}");
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
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
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        Invoke("DisplayNextSentence", 3);
    }
    public void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}