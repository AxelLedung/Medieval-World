using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCScript : MonoBehaviour, InteractableObject
{
    public GameObject NPC;
    public PlayerActionScript playerAction;

    public TextAsset textFile;
    public string[] textLines;
    public TextAsset answers;
    public string[] answersList;

    int currentLine;
    int endAtLine;
    void Awake()
    {
        NPC = this.gameObject;
        playerAction = gameObject.GetComponent<PlayerActionScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        var npcDialogueInterface = this.GetComponent<NPCDialogueInterface>();
        npcDialogueInterface.StartDialogue();
        
    }

}
