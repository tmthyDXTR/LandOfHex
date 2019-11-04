using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public static GameState GState;
    private TextMeshProUGUI stateText;
    
    public int gameTurn;
    public int playerTurn;

    public int p1_AP; // Action Points
    public int p2_AP;

    public State state;
    public enum State
    {
        Inactive,
        SetMove,
        SetInfluence,
        SetBuilding,
    }

    private void OnEnable()
    {
        if (GameState.GState == null)
        {
            GameState.GState = this;
        }
        stateText = GameObject.Find("Canvas").transform.Find("TextState").GetComponent<TextMeshProUGUI>();
        //state = State.Inactive;

        gameTurn = 1; // Start Game at Turn 1
        playerTurn = 1; // Player 1 starts

        p1_AP = 2; // Action Points at start
        p2_AP = 2;
    }

    void Update()
    {
        stateText.text = state.ToString();
    }
}