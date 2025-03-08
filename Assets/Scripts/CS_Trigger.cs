using System;
using UnityEngine;

public class CS_Trigger : MonoBehaviour
{
    public CutsceneManager cutsceneManager;
    public int cutsceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cutsceneManager.PlayCutscene(cutsceneIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cutsceneManager.HideDialogue();
        }
    }
}

