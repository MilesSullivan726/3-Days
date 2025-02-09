using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public GameObject nextDialogue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideNotification());
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            nextDialogue.SetActive(true);
            StartCoroutine(HideNotification());
        }*/
    }

    IEnumerator HideNotification()
    {
        nextDialogue.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
