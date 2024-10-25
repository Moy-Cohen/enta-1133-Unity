using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Map gameMap;

    public void Start()
    {
        Debug.Log("GameManager Start");

        gameMap = new Map();

        Debug.Log("Gamemanager Map Created");

        StartGame();
    }

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("Hello World");
    }
}
