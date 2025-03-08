using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;

    public void ShowDialogue(string text)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = text;
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }
}