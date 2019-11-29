using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    private Image character;
 //   private int[] startcharacter = { 0, 1, 3, 2, 4 };
    // Start is called before the first frame update
    private int[] CharacterArray = { 0, 1, 3, 2, 4 };
    private int CharacterArraySize = 5;
    void Start()
    {
        character = transform.Find("Panel/a1").GetComponent<Image>();
        character.enabled = false;
        character = transform.Find("Panel/a2").GetComponent<Image>();
        character.enabled = false;
        character = transform.Find("Panel/b1").GetComponent<Image>();
        character.enabled = false;
        character = transform.Find("Panel/b2").GetComponent<Image>();
        character.enabled = false;
        character = transform.Find("Panel/x1").GetComponent<Image>();
        character.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int Num;
        Num = GameObject.Find("MessageUI").GetComponent<Message>().messageNum;

        if (Num < CharacterArraySize)
        {
            Displaycharacter(CharacterArray[Num]);
        }
        if (false == GameObject.Find("MessageUI").GetComponent<Message>().transform.GetChild(0).gameObject.activeSelf)
        {
            character.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }
    }


    void Setcharacter(int[] characternum, int size) 
    {
        CharacterArray = characternum;
        CharacterArraySize = size;
        //int Num;
        //Num = GameObject.Find("MessageUI").GetComponent<Message>().messageNum;
        /*
        Displaycharacter(characternum[Num]);
        character.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        */
    }




    void Displaycharacter(int characternum)
    {
        switch(characternum)
        {
            case 0:
                character.enabled = false;
                character = transform.Find("Panel/a1").GetComponent<Image>();
                character.enabled = true;
                break;
            case 1:
                character.enabled = false;
                character = transform.Find("Panel/a2").GetComponent<Image>();
                character.enabled = true;
                break;
            case 2:
                character.enabled = false;
                character = transform.Find("Panel/b1").GetComponent<Image>();
                character.enabled = true;
                break;
            case 3:
                character.enabled = false;
                character = transform.Find("Panel/b2").GetComponent<Image>();
                character.enabled = true;
                break;
            case 4:
                character.enabled = false;
                character = transform.Find("Panel/x1").GetComponent<Image>();
                character.enabled = true;
                break;
            default:
                character.enabled = false;
                break;


        }
    }
    //　他のスクリプトから新しいメッセージを設定しUIをアクティブにする
    public void SetCharacterPanel(int[] character,int size)
    {
        Setcharacter(character, size);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
