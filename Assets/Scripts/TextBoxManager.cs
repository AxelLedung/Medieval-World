using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public static TextBoxManager instance;

    public GameObject textBox;
    public TextMeshProUGUI theText;

    public GameObject answerBox;
    public TextMeshProUGUI answerButton1;
    public TextMeshProUGUI answerButton2;
    public TextMeshProUGUI answerButton3;
    public TextMeshProUGUI answerButton4;
    public TextMeshProUGUI[] answerButtons;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        answerBox.SetActive(false);
        answerButtons = new TextMeshProUGUI[4];
        answerButtons[0] = answerButton1;
        answerButtons[1] = answerButton2;
        answerButtons[2] = answerButton3;
        answerButtons[3] = answerButton4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowDialogue(string dialogue, string[] answers)
    {
        theText.text = dialogue;
        textBox.SetActive(true);
        answerBox.SetActive(true);
        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] != null)
            {
                answerButtons[i].text = i + 1 + ". " + answers[i];
            }
            if (answers.Length < 4)
            {
                int empty = 4 - answers.Length;
                for (int j = 0; j < empty; j++)
                {
                    answerButtons[j + answers.Length].text = null;
                }
            }
        }        
    }
    public void ResetDialogue()
    {
        textBox.SetActive(false);
        answerBox.SetActive(false);
        
    }
    public void NextPage()
    {
        
    }
}
