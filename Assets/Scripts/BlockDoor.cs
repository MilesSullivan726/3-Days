using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour
{

    public bool clipBoardRead = false;
    public GameObject dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clipBoardRead)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogue.SetActive(true);
        }
    }
}
