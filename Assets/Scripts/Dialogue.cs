using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textCompenent;
    private int index;
    public string[] lines;
    public float textSpeed;
    public GameObject playerPortrait;
    public GameObject fatherPortrait;
    public GameObject choiceOptions;
    public int[] playerLines;
    public int[] fatherLines;
    public int[] choiceLines;
    public int choice1Response;
    public int choice2Response;
    private int choiceIndex;
    private bool canMakeChoice = false;
    private bool choiceMade = false;
    private bool isFatherPortraitActive = false;
    private bool isPlayerPortraitActive = false;

    // Start is called before the first frame update
    void Start()
    {
        textCompenent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textCompenent.text == lines[index] && !canMakeChoice)
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
                index = choice1Response - 1;
                canMakeChoice = false;
                choiceMade = true;
                NextLine();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
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
            textCompenent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
   
    }

    void DisplayPortraits(int index)
    {
        
        Debug.Log(index);
        
        // display player portrait on these lines
        for (int i = 0; i < playerLines.Length ; i++)
        {

            {
                if (index == playerLines[i])
                {
                    playerPortrait.SetActive(true);
                    isPlayerPortraitActive = true;
                    break; // No need to continue checking other lines
                }
            }

            // If no matching father line is found, hide the father portrait
            if (!isPlayerPortraitActive)
            {
                playerPortrait.SetActive(false);
            }
        }
        // display father portrait on these lines
        for (int j = 0; j < fatherLines.Length; j++)
        {
            {
                if (index == fatherLines[j])
                {
                    fatherPortrait.SetActive(true);
                    isFatherPortraitActive = true;
                    break; // No need to continue checking other lines
                }
            }

            // If no matching father line is found, hide the father portrait
            if (!isFatherPortraitActive)
            {
                fatherPortrait.SetActive(false);
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
}
