using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Sprite leftCharacter;
    public Sprite rightCharacter;
    public Text nameText;
    public Text dialogueText;

    private static Queue<Sentence> sentences;
    private static List<Sprite> leftCharacterOptions;
    private static List<Sprite> rightCharacterOptions;

    private void Start()
    {
        sentences = new Queue<Sentence>();
    }

    private void SetLeftSprite(Sprite sprite)
    {
        leftCharacter = sprite;
    }

    private void SetRightSprite(Sprite sprite)
    {
        rightCharacter = sprite;
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

        // animate appearing dialogue box
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
        leftCharacter = leftCharacterOptions[leftIndex];

        int rightIndex = sentence.rightSpriteIndex < rightCharacterOptions.Count ? sentence.rightSpriteIndex : 0;
        rightCharacter = rightCharacterOptions[rightIndex];
    }

    private void EndDialogue()
    {
        // animate disappearing dialogue box
    }
}
