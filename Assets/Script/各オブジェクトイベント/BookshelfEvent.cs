using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfEvent : MonoBehaviour
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
        int[] serif = new int[1];
        int size = 1;
        int Result = Random.Range(1, 4);
        switch (Result)
        {
            case 1:
                message = "本棚ですね";
                serif[0] = 1;
                break;
            case 2:
                message = "何かヒントになる本があるかもしれません。";
                serif[0] = 3;
                break;
            case 3:
                message = "この中のどれかスイッチになってて・・・<>" + "押したら秘密の扉が開くかも・・・<>" + "なーんちゃって";
                serif = new int[3];
                size = 3;
                serif[0] = 3;
                serif[1] = 3;
                serif[2] = 4;
                break;
        }
        GameObject.Find("MessageUI").GetComponent<Message_Game>().SetMessagePanel(message);
        GameObject.Find("CharacterUI").GetComponent<Character_Game>().SetCharacterPanel(serif, size);


    }
}
