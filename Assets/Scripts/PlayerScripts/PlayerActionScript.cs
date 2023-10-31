using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerActionScript : MonoBehaviour
{
    public PlayerCameraScript playerCameraScript;
    public NPCDialogueScript npcDialogueScript;

    public int lastAnswer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    void ProcessInputs()
    {        
        if (playerCameraScript.LookingAtObject != null)
        {
            if (playerCameraScript.LookingAtObject.tag == "Interactable" && UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                
                var interactedObject = playerCameraScript.LookingAtObject.GetComponent<InteractableObject>();
                interactedObject.Interact();
                if (TextBoxManager.instance.answerBox.activeSelf == true)
                {
                    if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        lastAnswer = 0;
                    }
                    else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        lastAnswer = 1;
                    }
                    else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        lastAnswer = 2;
                    }
                    else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        lastAnswer = 3;
                    }
                }
            }
            else if (playerCameraScript.LookingAtObject.tag != "Interactable")
            {
                TextBoxManager.instance.ResetDialogue();
            }
        }
        else if (playerCameraScript.LookingAtObject == null)
        {
            TextBoxManager.instance.ResetDialogue();
        }
        
    }
}
