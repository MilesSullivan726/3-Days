using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int choiceOneDecision; // 1 = vanilla, 2 = chocolate
    public GameObject dayTwoDialogue;
    public static GameManager Instance;

    

    

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);

        Debug.Log(SceneManager.GetActiveScene().name);

       

        if (SceneManager.GetSceneByName("Day 2").isLoaded == true)
        {
            Debug.Log("Day 2");
            Debug.Log(choiceOneDecision);

            if (choiceOneDecision == 1)
            {
                dayTwoDialogue.GetComponent<Dialogue>().index = 0;
            }

            else if (choiceOneDecision == 2)
            {
                dayTwoDialogue.GetComponent<Dialogue>().index = 1;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            SceneManager.LoadScene("Day 2", LoadSceneMode.Single);
        }

       
    }

 
}
