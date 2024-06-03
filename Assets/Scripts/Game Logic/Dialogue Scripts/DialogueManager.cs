using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public TextMeshPro player1Text;
    public TextMeshPro player2Text;

    public GameObject player1Follow;
    public GameObject player2Follow;

    Queue<DialogueLine> sentences = new Queue<DialogueLine>();
    bool IsRunningDialog = false;

    Dialogue? LastDialogue = null;
    public int DialogueFrequency = 30;
    public int DialogueChance = 25;

    List<Dialogue> dialogues = new List<Dialogue>
        {
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 1", text = "You need to stop buying sunglasses! It's unhealthy, Sarah" },
                    new DialogueLine { name = "Player 2", text = "You're just jealous." },
                    new DialogueLine { name = "Player 1", text = "I'm not jealous! They just shouldn't take up multiple rooms in our house!!!!"}
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
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "Why are you never home?" },
                    new DialogueLine { name = "Player 1", text = "You don't even like it when I'm home." },
                    new DialogueLine { name = "Player 1", text = "Besides, who pays the bills in this house? ME!!!" },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "Why do you trash the living room during your stupid sporting 'events'?" },
                    new DialogueLine { name = "Player 1", text = "Hey, nothing beats being an American Football fan." },
                    new DialogueLine { name = "Player 1", text = "You wouldn't understand that type of dedication." },
                }
            },

            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "OH MY GOODNESS!!!! WHY IS THERE A LIZARD IN HERE?!?! GET IT AWAY!!" },
                    new DialogueLine { name = "Player 1", text = "Oh, you mean Ralph? I thought he would be a great pet." },
                    new DialogueLine { name = "Player 2", text = "YOU WILL GET IT OUT OF THIS HOUSE OR YOU WILL FEEL MY WRATH!!!!" },
                    new DialogueLine { name = "Player 1", text = "Okay! Okay! I'll bring it back to the shelter :( I'll miss you, Ralph." },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 1", text = "SARAH! Why are all the lights on in the house???" },
                    new DialogueLine { name = "Player 2", text = "I need a reason to wear sunglasses inside." },
                    new DialogueLine { name = "Player 1", text = "You are making the electricty bill 5 times as much!!! It's ridiculous!!!" },
                }
            },
                        // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "No, no, no, stop it" },
                    new DialogueLine { name = "Player 1", text = "What have I done?" },
                    new DialogueLine { name = "Player 2", text = "What haven't you done?" },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 2", text = "Are you cheating on me with our neighbor?" },
                    new DialogueLine { name = "Player 1", text = "Cathy? The crazy cat lady? No." },
                    new DialogueLine { name = "Player 2", text = "Good, that's good. I'm clearly better." },
                    new DialogueLine { name = "Player 1", text = "*Whispers under his breath* Not Cathy, but the babysitter? She fineeeee ;)" },
                }
            },
                        // Bill & Sarah
            new Dialogue
            {
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Player 1", text = "Your brother stopped by yesterday. Can you make him stop glaring at me? He hate me!" },
                    new DialogueLine { name = "Player 2", text = "I normally wouldn't say this, but David can glare as much as he wants." },
                    new DialogueLine { name = "Player 1", text = "Damnit Sarah! I guess I'll just tell him that his sunglasses collection is better!" },
                    new DialogueLine { name = "Player 2", text = "No!!!! You wouldn't, would you?!?!?!?!" },
                }
            }
        };

    // Start is called before the first frame update
    void Start()
    {
        ClearText();

        InvokeRepeating("RandomDialogueStarter", 20, DialogueFrequency);
    }

    public void RandomDialogueStarter()
    {
        if (Random.Range(0, 100) <= DialogueChance)
        {
            if (IsRunningDialog == false || dialogues.Count != 0)
            {
                int dialogueChosen;
                do
                {
                    dialogueChosen = Random.Range(0, dialogues.Count - 1);
                } while (dialogues[dialogueChosen] == LastDialogue);

                if (dialogues[dialogueChosen] != LastDialogue)
                {
                    LastDialogue = dialogues[dialogueChosen];
                    StartDialogue(dialogues[dialogueChosen]);
                }
            }
        }
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
            player1Follow.SetActive(true);
            player1Text.text = sentence.text;
        }
        else
        {
            player2Follow.SetActive(true);
            player2Text.text = sentence.text;
        }
        Invoke("DisplayNextSentence", 4);
    }

    public void ClearText()
    {
        player1Text.text = "";
        player2Text.text = "";
        player2Follow.SetActive(false);
        player1Follow.SetActive(false);
    }
    public void EndDialogue()
    {
        IsRunningDialog = false;
        Debug.Log("End of conversation");
    }
}