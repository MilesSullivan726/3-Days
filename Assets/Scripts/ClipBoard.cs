using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{

    public GameObject doorWay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            doorWay.GetComponent<BlockDoor>().clipBoardRead = true;
        }
    }
}
