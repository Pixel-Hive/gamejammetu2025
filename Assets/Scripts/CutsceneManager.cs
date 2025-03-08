using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

[System.Serializable]
public class CutsceneEvent
{
    public float delay;
    public string eventType;
    public string eventData;
}


[System.Serializable]
public class Cutscene
{
    public string name;
    public CutsceneEvent[] events;
}

public class CutsceneManager : MonoBehaviour
{
        public Cutscene[] cutscenes;
        private bool isPlaying = false;
    
        public void PlayCutscene(int idx)
        {
            if (!isPlaying && idx >= 0 && idx < cutscenes.Length)
            {
                StartCoroutine(PlayCutsceneCoroutine(cutscenes[idx]));
            }
        }
    private IEnumerator PlayCutsceneCoroutine(Cutscene cutscene)
    {
            isPlaying = true;
            foreach(var cutsceneEvent in cutscene.events)
            {
                yield return new WaitForSeconds(cutsceneEvent.delay);
    
                switch (cutsceneEvent.eventType)
                {
                    case "Dialogue":
                        ShowDialogue(cutsceneEvent.eventData);
                        break;
                    case "CameraMove":
                        MoveCamera(cutsceneEvent.eventData);
                        break;
                    case "CharacterMove":
                        MoveCharacter(cutsceneEvent.eventData);
                        break;
                }
            }
        isPlaying = false;
    }
    private Vector3 ParseVec3(string data)
    {
        string[] parts = data.Split('.');
        return new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
    }

    public DialogueManager dialogueManager;
    private void ShowDialogue(string data)
    {
        dialogueManager.ShowDialogue(data);
    }

    public void HideDialogue()
    {
        dialogueManager.HideDialogue();
    }


    public CameraController cameraController;
    private void MoveCamera(string data)
    {
        Vector3 targetPosition = ParseVec3(data);
        cameraController.MoveTo(targetPosition);
    }


    public CharacterController characterController;
    private void MoveCharacter(string data)
    {
        Vector3 targetPos = ParseVec3(data);
        characterController.MoveTo(targetPos);
    }   
}


    
