using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public SpriteRenderer leftCharacter;
    public SpriteRenderer rightCharacter;
    public Text nameText;
    public Text dialogueText;

    private static Queue<Sentence> sentences;
    private static List<Sprite> leftCharacterOptions;
    private static List<Sprite> rightCharacterOptions;

    private void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // refresh
        sentences.Clear();
        leftCharacterOptions.Clear();
        rightCharacterOptions.Clear();

        leftCharacter = null;
        rightCharacter = null;
        nameText.text = "";
        dialogueText.text = "";


        // enqueue sentences
        foreach (Sentence s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        // update sprite options
        foreach (Sprite s in dialogue.leftSprites)
        {
            leftCharacterOptions.Add(s);
        }
        foreach (Sprite s in dialogue.rightSprites)
        {
            rightCharacterOptions.Add(s);
        }

        // TODO: animate appearing dialogue box, potentially by setting x and y coordinates
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sentence sentence = sentences.Dequeue();
        nameText.text = sentence.speakerName;
        dialogueText.text = sentence.text;

        int leftIndex = sentence.leftSpriteIndex < leftCharacterOptions.Count ? sentence.leftSpriteIndex : 0;
        leftCharacter.sprite = leftCharacterOptions[leftIndex];

        int rightIndex = sentence.rightSpriteIndex < rightCharacterOptions.Count ? sentence.rightSpriteIndex : 0;
        rightCharacter.sprite = rightCharacterOptions[rightIndex];
    }

    private void EndDialogue()
    {
        // TODO: animate disappearing dialogue box, invisible?
    }
}
