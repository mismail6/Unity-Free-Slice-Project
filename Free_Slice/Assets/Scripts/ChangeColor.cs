using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject sword = GameObject.Find("Player/Main Camera/Player_Sword2");
        GameObject sword1 = GameObject.Find("Player/Main Camera/Player_Sword");
        sword.SetActive(true);
        sword1.SetActive(false);
        Debug.Log("FOUND BLACK SWORD");
    }
}
