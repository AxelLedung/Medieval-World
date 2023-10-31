using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueScript : MonoBehaviour
{
    public static NPCDialogueScript instance; 
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual string[] BreakDownTextFile(TextAsset textFile)
    {
        string[] textLines;
        if (textFile != null)
        {
            textLines = (textFile.text.Split("|"));
            return textLines;
        }
        else
        {
            Debug.Log("TextFile is missing!");
            return null;
        }
    }
}
