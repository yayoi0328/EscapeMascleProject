using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        string message = "鉄格子ででられないみたいですね";
        int[] serif = { 3 };
        GameObject.Find("MessageUI").GetComponent<Message_Game>().SetMessagePanel(message);
        GameObject.Find("CharacterUI").GetComponent<Character_Game>().SetCharacterPanel(serif, 1);


    }
}
