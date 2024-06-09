using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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
    public int DialogueChance = 75;

    List<Dialogue> dialogues = new List<Dialogue>
        {
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "You need to stop buying sunglasses! It's unhealthy, Sarah" },
                    new DialogueLine { name = "Sarah", text = "You're just jealous." },
                    new DialogueLine { name = "Bill", text = "I'm not jealous! They just shouldn't take up multiple rooms in our house!!!!"}
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I still cannot believe that you used COMIC SANS on our wedding invites. What were you thinking, Bill?!?" },
                    new DialogueLine { name = "Bill", text = "This again? Really? But to be fair, I thought the font looked good!" },
                    new DialogueLine { name = "Sarah", text = "You're unbelievable." },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I HATE YOU!!!!!" },
                    new DialogueLine { name = "Bill", text = "I gathered that, yeah. It's why we're in court, Sarah." },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Why are you never home?" },
                    new DialogueLine { name = "Bill", text = "You don't even like it when I'm home." },
                    new DialogueLine { name = "Bill", text = "Besides, who pays the bills in this house? ME!!!" },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Why do you trash the living room during your stupid sporting 'events'?" },
                    new DialogueLine { name = "Bill", text = "Hey, nothing beats being an American Football fan." },
                    new DialogueLine { name = "Bill", text = "You wouldn't understand that type of dedication." },
                }
            },

            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "OH MY GOODNESS!!!! WHY IS THERE A LIZARD IN HERE?!?! GET IT AWAY!!" },
                    new DialogueLine { name = "Bill", text = "Oh, you mean Ralph? I thought he would be a great pet." },
                    new DialogueLine { name = "Sarah", text = "YOU WILL GET IT OUT OF THIS HOUSE OR YOU WILL FEEL MY WRATH!!!!" },
                    new DialogueLine { name = "Bill", text = "Okay! Okay! I'll bring it back to the shelter :( I'll miss you, Ralph." },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "SARAH! Why are all the lights on in the house???" },
                    new DialogueLine { name = "Sarah", text = "I need a reason to wear sunglasses inside." },
                    new DialogueLine { name = "Bill", text = "You are making the electricty bill 5 times as much!!! It's ridiculous!!!" },
                }
            },
                        // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "No, no, no, stop it" },
                    new DialogueLine { name = "Bill", text = "What have I done?" },
                    new DialogueLine { name = "Sarah", text = "What haven't you done?" },
                }
            },
            // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Are you cheating on me with our neighbor?" },
                    new DialogueLine { name = "Bill", text = "Cathy? The crazy cat lady? No." },
                    new DialogueLine { name = "Sarah", text = "Good, that's good. I'm clearly better." },
                    new DialogueLine { name = "Bill", text = "*Whispers under his breath* Not Kathy, but the babysitter? She fineeeee ;)" },
                }
            },
                        // Bill & Sarah
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Sarah",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "Your brother stopped by yesterday. Can you make him stop glaring at me? He hates me!" },
                    new DialogueLine { name = "Sarah", text = "I normally wouldn't say this, but David can glare as much as he wants." },
                    new DialogueLine { name = "Bill", text = "Damnit Sarah! I guess I'll just tell him that his sunglasses collection is better!" },
                    new DialogueLine { name = "Sarah", text = "No!!!! You wouldn't, would you?!?!?!?!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "How are you doing, darling?" },
                    new DialogueLine { name = "Jessica", text = "SARAH FOUND OUT!!! You told me that she wouldn't!!!!" },
                    new DialogueLine { name = "Bill", text = "She doesn't know. She thinks I'm cheating on her with the cat lady." },
                    new DialogueLine { name = "Jessica", text = "YOU'RE CHEATING ON ME WITH THE CAT LADY!?!?!?!??>" },
                    new DialogueLine { name = "Bill", text = "Do you ever listen??" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Ooh, what's our astrology compatibility? I'm a gemini." },
                    new DialogueLine { name = "Bill", text = "I don't know. I was born in November though." },
                    new DialogueLine { name = "Jessica", text = "November? You're a scorpio??? We can't be together anymore!! We aren't compatible!!!!!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "WHY IS THERE A SMOOTHIE EXPLOSION IN THE KITCHEN??? WHAT DID YOU DO??" },
                    new DialogueLine { name = "Jessica", text = "Oh, yeah, like I forgot to put the lid on the blender." },
                    new DialogueLine { name = "Jessica", text = "I mean, things smell fruity now, so." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "I know we're fighting, but will you still be buying my that Gucci purse for my birthday???" },
                    new DialogueLine { name = "Bill", text = "No!!! You told Sarah that you thought I was looking at other women." },
                    new DialogueLine { name = "Bill", text = "I'm cheating on her with you! Why would you even mention that??? Do you WANT to get caught?" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "I'm going to be a little bit late on the laywer payments. I pay too much child support, you see." },
                    new DialogueLine { name = "Saul", text = "You're already two weeks late. I've charged you $5000 in interest." },
                    new DialogueLine { name = "Bill", text = "$5000?? I can't pay that." },
                    new DialogueLine { name = "Saul", text = "Then instead of you or Sarah getting the house, it might be mine instead." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "Why are we even discussing alimony? She’s the one who wanted the divorce!" },
                    new DialogueLine { name = "Saul", text = "Rules are rules. " },
                    new DialogueLine { name = "Bill", text = "Rules are rules - what sort of lawyer says that." },
                    new DialogueLine { name = "Saul", text = "*Smiles*" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "I'm not sure that you're going to end up getting the truck." },
                    new DialogueLine { name = "Bill", text = "That's my truck!!! She hates trucks!!!" },
                    new DialogueLine { name = "Saul", text = "She hates you more than she hates the truck. How tragic." },
                    new DialogueLine { name = "Saul", text = "It'll cost you more if you want me to guarantee you get the truck..." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "I don’t see why we have to give her joint custody. She's never around for the kids!" },
                    new DialogueLine { name = "Saul", text = "The court tends to favor joint custody, but we can challenge that." },
                    new DialogueLine { name = "Saul", text = "More challenges mean more hearings, and more hearings mean... well, you get it." },
                    new DialogueLine { name = "Bill", text = "More money for you." },
                    new DialogueLine { name = "Saul", text = "Exactly! But also, potentially more time with your kids. It’s a win-win!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "Oh, hello there! Want to come inside and meet my new kittens? I just got four more!" },
                    new DialogueLine { name = "Bill", text = "Uh, no thanks. My wife already thinks we’re having an affair." },
                    new DialogueLine { name = "Kathy", text = "An affair? With me? Oh, honey, you’re not nearly as interesting as my cats." },
                    new DialogueLine { name = "Kathy", text = "Besides, I thought you were more into the babysitter." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "Oh, hello there! Want to come inside and meet my new kittens? I just got four more!" },
                    new DialogueLine { name = "Bill", text = "Uh, no thanks. My wife already thinks we’re having an affair." },
                    new DialogueLine { name = "Kathy", text = "An affair? With me? Oh, honey, you’re not nearly as interesting as my cats." },
                    new DialogueLine { name = "Kathy", text = "Besides, I thought you were more into the babysitter." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "I hear you're getting divorced. Maybe she’d take you back if you brought her a kitten." },
                    new DialogueLine { name = "Bill", text = "Somehow, I think a kitten isn’t going to fix this mess." },
                    new DialogueLine { name = "Kathy", text = "Suit yourself. But just so you know, Mr. Snuggles gives great relationship advice." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "I will NEVER forgive you for kicking one of my cats." },
                    new DialogueLine { name = "Bill", text = "I didn't see it!! It jumped in front of me!!!" },
                    new DialogueLine { name = "Kathy", text = "He! Mr. Fluffy is a fine gentleman. He may be blind, but there is no excuse for you!!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "You know, Bill, you never deserved my sister." },
                    new DialogueLine { name = "Bill", text = "Oh really? And what makes you the expert on my marriage?" },
                    new DialogueLine { name = "David", text = "I’ve known Sarah my whole life. She’s way out of your league." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Bill", text = "Your sister is nuts! She thinks I’m cheating with the cat lady next door." },
                    new DialogueLine { name = "David", text = "Well, are you?" },
                    new DialogueLine { name = "Bill", text = "Of course not! It’s the babysitter. I mean, uh, never mind." },
                    new DialogueLine { name = "David", text = "The babysitter? Seriously? You’re unbelievable." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "You always were a lousy husband." },
                    new DialogueLine { name = "Bill", text = "And you always were a lousy brother-in-law." },
                    new DialogueLine { name = "David", text = "At least I'm not the one breaking her heart!" },
                    new DialogueLine { name = "Bill", text = "No, you're just the one making it worse!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Bill",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "You're a terrible influence on my niece and nephew." },
                    new DialogueLine { name = "Bill", text = "Oh please, they love me! They think I'm a superhero." },
                    new DialogueLine { name = "David", text = "A superhero? More like a super zero." },
                    new DialogueLine { name = "Bill", text = "Well, at least I don't wear socks with sandals." },
                }
            },
             new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I can't believe Bill would cheat on me with that crazy cat lady Kathy!" },
                    new DialogueLine { name = "Jessica", text = "Yeah, that's just... awful." },
                    new DialogueLine { name = "Sarah", text = "You know, I thought you might have noticed something." },
                    new DialogueLine { name = "Sarah", text = "I mean, you're around our house all the time." },
                    new DialogueLine { name = "Jessica", text = "Oh, me? No, I didn't notice anything unusual. Just... cats. Lots of cats." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "You know, sometimes I wonder if Bill is using Kathy as a cover." },
                    new DialogueLine { name = "Jessica", text = "A cover? For what?" },
                    new DialogueLine { name = "Sarah", text = "Maybe he's actually into someone else." },
                    new DialogueLine { name = "Jessica", text = "Like the babysitter?" },
                    new DialogueLine { name = "Sarah", text = "Not you! You're too sweet." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I think I need a break." },
                    new DialogueLine { name = "Jessica", text = "A vacation sounds great! Maybe Bill and I... I mean, Bill and Kathy will sort things out." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Why am I paying so much in legal fees?" },
                    new DialogueLine { name = "Saul", text = "Justice isn't cheap, Sarah. Neither am I." },
                    new DialogueLine { name = "Sarah", text = "At this rate, I'll be broke before the divorce is final!" },
                    new DialogueLine { name = "Saul", text = "Better broke than married to Bill, right?" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I can't believe you let Bill take my sunglasses collection!" },
                    new DialogueLine { name = "Saul", text = "Sarah, we got you the house and the car. Isn’t that more important?" },
                    new DialogueLine { name = "Sarah", text = "Not if I can’t leave the house without my favorite shades!!!!!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Why does it feel like I'm the only one losing here?" },
                    new DialogueLine { name = "Saul", text = "Because you haven't seen my final invoice yet." },
                    new DialogueLine { name = "Sarah", text = "Great, that's just what I needed." },
                    new DialogueLine { name = "Saul", text = "Look on the bright side, Sarah. At least Bill won't get your money. I will." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Saul, did you see the sunglasses Bill bought his new girlfriend?" },
                    new DialogueLine { name = "Saul", text = "Sarah, let's focus on the case, not his new girlfriend." },
                    new DialogueLine { name = "Sarah", text = "It’s personal! He’s using my style against me!" },
                    new DialogueLine { name = "Saul", text = "Let’s focus on your assets first, then we can worry about fashion wars." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I know you're cheating with my husband, Kathy!" },
                    new DialogueLine { name = "Kathy", text = "Cheating? With Bill? Don't flatter yourself. I'm too busy with my cats." },
                    new DialogueLine { name = "Sarah", text = "Liar! I see how you look at him." },
                    new DialogueLine { name = "Kathy", text = "I look at him like he’s an annoyance, just like you." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "I bet you’re thrilled I’m divorcing Bill so you can have him all to yourself." },
                    new DialogueLine { name = "Kathy", text = "Thrilled? Please, I’d rather adopt another cat." },
                    new DialogueLine { name = "Sarah", text = "Just stay away from him!" },
                    new DialogueLine { name = "Kathy", text = "Trust me, I’m staying far away from both of you." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Sarah", text = "Bill must be over there all the time because you’re giving him something I can’t." },
                    new DialogueLine { name = "Kathy", text = "Yes, peace and quiet. Maybe you should try it." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Your sunglasses are contested not. I’ll be coming for your prized Gucci shades." },
                    new DialogueLine { name = "Sarah", text = "Over my dead body, David. The Gucci shades stay with me." },
                    new DialogueLine { name = "David", text = "This means war, Sarah. Sunglasses war." },
                    new DialogueLine { name = "Sarah", text = "May the best collection win!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "You know, this obsession with sunglasses isn’t healthy." },
                    new DialogueLine { name = "Sarah", text = "Look who’s talking! You built an entire display case just for yours." },
                    new DialogueLine { name = "David", text = "Yes, but I’m not using a divorce to expand my collection!" },
                    new DialogueLine { name = "Sarah", text = "Just wait until you see my new display. It’ll be legendary." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Sarah, you have to prioritize. House, car, then sunglasses." },
                    new DialogueLine { name = "Sarah", text = "The sunglasses are the priority, David!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Sarah",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Your sunglasses reign is ending, Sarah" },
                    new DialogueLine { name = "Sarah", text = "NO! Mine will always be superior." },
                    new DialogueLine { name = "David", text = "I heard that you might lose them in the divorce." },
                    new DialogueLine { name = "David", text = "Besides, who is gonna pay for the newest raybans?" },
                    new DialogueLine { name = "Sarah", text = "Why you little-" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Saul, you have to make sure Sarah doesn't find out about me and Bill." },
                    new DialogueLine { name = "Saul", text = "Jessica, my job is to handle the divorce, not to cover up your affair." },
                    new DialogueLine { name = "Jessica", text = "But if she finds out, it'll make everything worse!" },
                    new DialogueLine { name = "Saul", text = "Worse for you, maybe. For me, it's more money." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Saul, can't you do something to make Sarah less angry?" },
                    new DialogueLine { name = "Saul", text = "I’m a lawyer, not a therapist. Anger management isn't in my job description." },
                    new DialogueLine { name = "Jessica", text = "But you're so good at talking to people. I could, ah, maybe provide some services for you." },
                    new DialogueLine { name = "Saul", text = "Flattery won't get you anywhere, Jessica. You'd be a leech to my money, and we can't have that now." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Saul",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "What if Sarah finds out about me and Bill?" },
                    new DialogueLine { name = "Saul", text = "Then my fees go up, and your life gets complicated. Simple as that." },
                    new DialogueLine { name = "Jessica", text = "You're such a heartless jerk!" },
                    new DialogueLine { name = "Saul", text = "And you're a homewrecker. We all have our roles to play." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Kathy, you need to tell Sarah that nothing's going on between you and Bill." },
                    new DialogueLine { name = "Kathy", text = "Why should I? It’s not my fault she’s paranoid." },
                    new DialogueLine { name = "Jessica", text = "Because if she keeps thinking it’s you, she’ll never find out about me!" },
                    new DialogueLine { name = "Kathy", text = "Oh, the babysitter in distress. How cliché." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Kathy, do you have to be so difficult?" },
                    new DialogueLine { name = "Jessica", text = "Sarah is going to go crazy on me if she finds out." },
                    new DialogueLine { name = "Kathy", text = "Good luck with that. Maybe you should take up knitting. It’s very calming." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Kathy, can you please mind your own business?" },
                    new DialogueLine { name = "Kathy", text = "When your business is this juicy, it’s hard to ignore." },
                    new DialogueLine { name = "Kathy", text = "Nothing has been this entertaining since my ex-husband went 'missing'." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Jessica",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Jessica", text = "Why do you keep hanging around Bill? Sarah's getting suspicious." },
                    new DialogueLine { name = "Kathy", text = "Hanging around Bill? I'm more interested in finding new cat food recipes." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "David",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Jessica, what are you doing here? Shouldn’t you be babysitting?" },
                    new DialogueLine { name = "Jessica", text = "Babysitting? Really? That’s all you think I do?" },
                    new DialogueLine { name = "David", text = "Well, you certainly aren’t winning any awards for discretion." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "David",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Why don’t you just leave my sister and her husband alone?" },
                    new DialogueLine { name = "Jessica", text = "Maybe because it’s none of your business, David." },
                    new DialogueLine { name = "David", text = "It is when you’re ruining my sister’s life." },
                    new DialogueLine { name = "Jessica", text = "She’s doing a fine job of that without my help." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "David",
                    "Jessica",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Jessica, you’re just digging yourself deeper." },
                    new DialogueLine { name = "Jessica", text = "And you’re just wasting your breath." },
                    new DialogueLine { name = "David", text = "This is going to blow up in your face." },
                    new DialogueLine { name = "Jessica", text = "Then I guess I’ll have to get some new shades for the explosion. Maybe I'll borrow a pair?" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "Kathy, stop making Sarah think you’re involved with Bill." },
                    new DialogueLine { name = "Kathy", text = "I'm not making her think anything. She jumped to that conclusion herself." },
                    new DialogueLine { name = "Saul", text = "Well, her 'conclusions' are making my job harder." },
                    new DialogueLine { name = "Kathy", text = "Sounds like a you problem, Saul." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "Kathy, I need you to stay out of Sarah and Bill's affairs." },
                    new DialogueLine { name = "Kathy", text = "Saul, my only concern is the well-being of my cats." },
                    new DialogueLine { name = "Saul", text = "Your cats are not the issue here, Kathy. This is about Sarah's future." },
                    new DialogueLine { name = "Kathy", text = "And Mr. Whiskers' future, Saul. Don't forget about him." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "Kathy",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "Kathy, I need you to be honest with me. Is there anything going on between you and Bill?" },
                    new DialogueLine { name = "Kathy", text = "Between me and Bill? No, Saul. The only thing between us is a fence." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "David, I understand you’re concerned, but you need to let me handle this divorce." },
                    new DialogueLine { name = "David", text = "Handle it? You've been dragging your feet for weeks, Saul!" },
                    new DialogueLine { name = "Saul", text = "A little bit more money for me never hurt anybody. Well... kinda." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "David, your interference is making this process more difficult." },
                    new DialogueLine { name = "David", text = "My interference? You’re the one who's been avoiding Sarah's calls! She needs her sunglasses!" },
                    new DialogueLine { name = "Saul", text = "David, you and your sister are not okay. Please let go of the whole sunglasses thing." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Saul",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Saul", text = "David, your constant questioning isn’t helping anyone." },
                    new DialogueLine { name = "David", text = "Isn’t helping? I’m just trying to make sure Sarah doesn’t get screwed over!" },
                    new DialogueLine { name = "Saul", text = "Sarah hired me for a reason, David. She trusts my judgment." },
                    new DialogueLine { name = "David", text = "Hmph!" },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Kathy",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "David, why are you always poking your nose into everyone's business?" },
                    new DialogueLine { name = "David", text = "Everyone’s business? Kathy, I’m just looking out for my sister's interests, unlike some people." },
                    new DialogueLine { name = "Kathy", text = "Looking out for Sarah? Is that why you’re so fixated on those sunglasses?" },
                    new DialogueLine { name = "David", text = "Those sunglasses are just one piece of the puzzle, Kathy. Something you wouldn’t understand." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Kathy",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "David", text = "Leave well enough alone? Kathy, stop pretending to be oblivious to what’s really going on." },
                    new DialogueLine { name = "Kathy", text = "Oblivious? David, I’m not the one who needs to get a grip on reality." },
                }
            },
            new Dialogue
            {
                names = new List<string>
                {
                    "Kathy",
                    "David",
                },
                sentences = new List<DialogueLine>
                {
                    new DialogueLine { name = "Kathy", text = "David, you seem awfully concerned about my relationship with Bill." },
                    new DialogueLine { name = "David", text = "Relationship? You call it a relationship when you're trying to steal my sister's husband?" },
                    new DialogueLine { name = "Kathy", text = "Steal? Oh, David, you watch too much daytime drama." },
                }
            },
        };

    List<Dialogue> availableDialogues;

    // Start is called before the first frame update
    void Start()
    {
        availableDialogues = dialogues.Where(dialogue => dialogue.names.Contains(GameValues.player1Name) && dialogue.names.Contains(GameValues.player2Name)).ToList();
        ClearText();
        if (availableDialogues.Count != 0)
        {
            InvokeRepeating("RandomDialogueStarter", 15, DialogueFrequency);
        }
    }

    public void RandomDialogueStarter()
    {
        if (Random.Range(0, 100) <= DialogueChance)
        {
            if (IsRunningDialog == false || availableDialogues.Count != 0)
            {
                int dialogueChosen;

                do
                {
                    dialogueChosen = Random.Range(0, availableDialogues.Count - 1);
                } while (availableDialogues[dialogueChosen] == LastDialogue);

                if (availableDialogues[dialogueChosen] != LastDialogue)
                {
                    LastDialogue = availableDialogues[dialogueChosen];
                    StartDialogue(availableDialogues[dialogueChosen]);
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