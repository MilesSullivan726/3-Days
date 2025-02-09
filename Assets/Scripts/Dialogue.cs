using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textCompenent;
    public int index;
    public string[] lines;
    public float textSpeed;
    public GameObject playerPortrait;
    public GameObject NPCPortrait;
    public GameObject choiceOptions;
    public GameObject keyItem;
    public GameObject fadeOut;
    public Player player;
    public Sprite[] playerExpressions;
    public Sprite[] NPCExpressions;
    private GameManager gameManager;
    public int[] playerLines;
    public int[] NPCLines;
    public int[] choiceLines;
    public int[] endDialogueLines;
    public int choice1Response;
    public int choice2Response;
    private int choiceIndex;
    private bool canMakeChoice = false;
    private bool choiceMade = false;
    private bool isNPCPortraitActive = false;
    private bool isPlayerPortraitActive = false;
    private bool endOfDialogue = false;
    public bool setIndex0 = true;
    public bool activateKeyItem = false;
    public bool isEndLevelDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        if (activateKeyItem)
        {
            keyItem.SetActive(true);
        }

        player.canMove = false;
        textCompenent.text = string.Empty;
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        if (setIndex0)
        {
            StartDialogue();
        }
        else
        {
            DisplayPortraits(index);
            StartCoroutine(TypeLine());
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndDialogueCheck(index);
            if (textCompenent.text == lines[index] && !canMakeChoice && endOfDialogue)
            {
                if (isEndLevelDialogue)
                {
                    fadeOut.SetActive(true);
                }
                gameObject.SetActive(false);
            }
            else if (textCompenent.text == lines[index] && !canMakeChoice)
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textCompenent.text = lines[index];
            }
        }

        if (canMakeChoice)
        {
          
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                GameManager.choiceOneDecision = 1;
                index = choice1Response - 1;
                canMakeChoice = false;
                choiceMade = true;
                NextLine();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                GameManager.choiceOneDecision = 2;
                index = choice2Response - 1;
                canMakeChoice = false;
                choiceMade = true;
                NextLine();
            }
        }
        
    }

    


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // show characters 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textCompenent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            
            index++;       
            DisplayPortraits(index);
            DisplayChoices(index);
            EndDialogueCheck(index);
            textCompenent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
   
    }

    void ChangeExpression(int index, bool isPlayer)
    {
        if (isPlayer)
        {
            playerPortrait.GetComponent<Image>().sprite = playerExpressions[index];
        }
        else
        {
            NPCPortrait.GetComponent<Image>().sprite = NPCExpressions[index];
        }
    }

    void DisplayPortraits(int index)
    {        
        // display player portrait on these lines
        for (int i = 0; i < playerLines.Length ; i++)
        {
            isPlayerPortraitActive = false;

            {
                if (index == playerLines[i])
                {
                    playerPortrait.SetActive(true);
                    isPlayerPortraitActive = true;
                    ChangeExpression(index, true);
                    break; // No need to continue checking other lines
                }
            }

            // If no matching player line is found, hide the player portrait
            if (!isPlayerPortraitActive)
            {
                playerPortrait.SetActive(false);
            }
        }
        // display father portrait on these lines
        for (int j = 0; j < NPCLines.Length; j++)
        {
            isNPCPortraitActive = false;
            {
                if (index == NPCLines[j])
                {
                    NPCPortrait.SetActive(true);
                    isNPCPortraitActive = true;
                    ChangeExpression(index, false);
                    break; // No need to continue checking other lines
                }
            }

            // If no matching father line is found, hide the father portrait
            if (!isNPCPortraitActive)
            {
                NPCPortrait.SetActive(false);
            }
        }
    }

    void DisplayChoices(int index)
    {
        for (int i = 0; i < choiceLines.Length; i++)
        {
            if (index == choiceLines[i])
            {
                choiceOptions.SetActive(true);
                canMakeChoice = true;
            }
            else
            {
                choiceOptions.SetActive(false);
                canMakeChoice = false;
            }
        }
    }
    void EndDialogueCheck(int index)
    {
        
        for (int i = 0; i < endDialogueLines.Length; i++)
        {
            if (index == endDialogueLines[i])
            {
                endOfDialogue = true;
                player.canMove = true;
            }
           
        }
    }
}
