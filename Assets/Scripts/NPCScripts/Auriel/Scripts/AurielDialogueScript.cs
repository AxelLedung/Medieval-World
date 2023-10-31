using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class AurielDialogueScript : MonoBehaviour, NPCDialogueInterface
{
    public TextAsset introTextSequence;
    public TextAsset questTextSequence;
    string[] textSequence;
    string[] currentOptions;
    string currentTextSequence;
    void Awake()
    {
        
    }
    void Start()
    {
        textSequence = NPCDialogueScript.instance.BreakDownTextFile(introTextSequence);
    }
    void Update()
    {
        LoadNextTextSequence();
    }
    public void StartDialogue()
    {
        TextBoxManager.instance.ShowDialogue(textSequence[0], currentOptions);
    }
    public void ExitDialogue()
    {

    }
    void LoadNextTextSequence()
    {
        if (currentTextSequence == null)
        {
            IntroTextSequence();
        }
        else if (currentTextSequence == introTextSequence.name)
        {
            QuestStartSequence();
        }
    }
    void IntroTextSequence()
    {
        textSequence = NPCDialogueScript.instance.BreakDownTextFile(introTextSequence);
        currentOptions = textSequence[1].Split('*');
        
        currentTextSequence = introTextSequence.name;
    }

    void QuestStartSequence()
    {

    }
    
}
