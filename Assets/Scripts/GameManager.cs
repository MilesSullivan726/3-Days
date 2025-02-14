using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int choiceOneDecision; // 1 = Good, 2 = Bad
    public static int choiceTwoDecision; // 1 = Good, 2 = Bad
    public GameObject dayThreeDialogue;
    public static GameManager Instance;

    

    

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        //DontDestroyOnLoad(this.gameObject);

        Debug.Log(SceneManager.GetActiveScene().name);

       

        if (SceneManager.GetSceneByName("Day 3").isLoaded == true)
        {

            if (choiceOneDecision == 1 && choiceTwoDecision == 1)
            {
                dayThreeDialogue.GetComponent<Dialogue>().index = 0;
            }

            else 
            {
                dayThreeDialogue.GetComponent<Dialogue>().index = 10;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

 
}
