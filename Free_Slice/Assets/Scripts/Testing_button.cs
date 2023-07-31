using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_button : MonoBehaviour
{
    GameObject g1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj1 = GameObject.FindWithTag("MyKatana");
        if (Input.GetKeyDown(KeyCode.T))
        {
            obj1.SetActive(false);
        }
    }
}
