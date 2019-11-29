using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEHT = 4;

    public GameObject PanelWalls;

    private int wallNo;

    // Start is called before the first frame update
    void Start()
    {
        wallNo = WALL_FRONT;
    }
    public void pushButtonRight()
    {
        wallNo++;
        if (wallNo > WALL_LEHT)
        {
            wallNo = WALL_FRONT;
        }
        displayWall();
    }
    public void pushButtonLEHT()
    {
        wallNo--;
        if (wallNo < WALL_FRONT)
        {
            wallNo = WALL_LEHT;
        }
        displayWall();
    }
    // Update is called once per frame
    void Update()
    {
   
    }
    void displayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:
                PanelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:
                PanelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:
                PanelWalls.transform.localPosition = new Vector3(-4000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEHT:
                PanelWalls.transform.localPosition = new Vector3(-6000.0f, 0.0f, 0.0f);
                break;
        }
    }
}
