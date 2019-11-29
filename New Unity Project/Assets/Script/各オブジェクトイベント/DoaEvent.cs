using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoaEvent : MonoBehaviour
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

        string message = "";
        int[] serif=new int[1];
        int Result = Random.Range(1,4);
        switch (Result) 
        {
            case 1:
                message = "これはドアですね";
                serif[0] = 1;
                break;
            case 2:
                message = "鍵がかかっててでられません";
                serif[0] = 3;
                break;
            case 3:
                message = "ぶちやぶりましょうか？";
                serif[0] = 4;
                break;
        }
        GameObject.Find("MessageUI").GetComponent<Message_Game>().SetMessagePanel(message);
        GameObject.Find("CharacterUI").GetComponent<Character_Game>().SetCharacterPanel(serif,1);


    }
}
