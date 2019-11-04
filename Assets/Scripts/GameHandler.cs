using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    public void SetInactive()
    {
        GameState.GState.state = GameState.State.Inactive;
        Debug.Log("Set state to : " + GameState.State.Inactive.ToString());
    }
    public void SetMove()
    {
        GameState.GState.state = GameState.State.SetMove;
        Debug.Log("Set state to : " + GameState.State.SetMove.ToString());
    }
    public void SetInfluence()
    {
        GameState.GState.state = GameState.State.SetInfluence;
        Debug.Log("Set state to : " + GameState.State.SetInfluence.ToString());
    }
    public void SetBuilding()
    {
        GameState.GState.state = GameState.State.SetBuilding;
        Debug.Log("Set state to : " + GameState.State.SetBuilding.ToString());
    }
}
