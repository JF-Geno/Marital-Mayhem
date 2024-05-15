using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public Queue<DialogueLine> sentences = new Queue<DialogueLine>();
    public TextMeshPro player1Text;
    public TextMeshPro player2Text;
    bool IsRunningDialog = false;
    List<Dialogue> dialogues = new List<Dialogue>
        {
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 1", text = "You need to stop buying sunglasses! Its unhealthy, Sarah!" },
                    new DialogueLine { name = "Player 2", text = "You're just jealous." },
                    new DialogueLine { name = "Player 1", text = "I would not consider having over 1000 pairs of sunglasses as reason for jealously. They take up multiple rooms in our house!!!!"}
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "I still cannot believe that you used COMIC SANS on our wedding invites. What were you thinking, Bill?!?" },
                    new DialogueLine { name = "Player 1", text = "This again? Really? But to be fair, I thought the font looked good!" },
                    new DialogueLine { name = "Player 2", text = "You're unbelievable." },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "I HATE YOU!!!!!" },
                    new DialogueLine { name = "Player 1", text = "I gathered that, yeah. It's why we're in court, Sarah." },
                }
            }
        };

    // Start is called before the first frame update
    void Start()
    {
        ClearText();

        RandomDialogueStarter();
    }

    void FixedUpdate()
    {
    }

    public void RandomDialogueStarter()
    {
        if (IsRunningDialog == false || dialogues.Count == 0)
        {
            if (Random.Range(0, 10) == 0)
            {
                StartDialogue(dialogues[Random.Range(0, dialogues.Count - 1)]);
            }
        }
        Invoke("RandomDialogeStarter", 1);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"Starting converstaion");
        IsRunningDialog = true;
        sentences.Clear();

        foreach (DialogueLine sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        ClearText();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine sentence = sentences.Dequeue();

        if (sentence.name == GameValues.player1Name)
        {
            player1Text.text = sentence.text;
        }
        else
        {
            player2Text.text = sentence.text;
        }
        Invoke("DisplayNextSentence", 3);
    }

    public void ClearText()
    {
        player1Text.text = "";
        player2Text.text = "";
    }
    public void EndDialogue()
    {
        IsRunningDialog = false;
        Debug.Log("End of conversation");
    }
}