using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] PlayerInput Player;
    public enum State 
    {
        Playing,
        Win,
        Lose,
           
    }
    public State CurrentState
    { get; private set; }

    public void OnPlayerDie()
    {
        if (CurrentState == State.Playing) return;
        CurrentState = State.Lose;
        Player.enabled = false;
    }


}
