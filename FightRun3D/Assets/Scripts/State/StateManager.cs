using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    MainMenu,
    InGame,
    GameOver,
    EndGame
}

public class StateManager : Singleton<StateManager>
{
    [HideInInspector]
    public State state;

    private void Start()
    {
        state = State.MainMenu;
    }


}
