using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateAction();
    public StateAction MainMenu;
    public StateAction InGame;
    public StateAction EndGame;
    public StateAction GameOver;


    public delegate void Point();
    public Point PlusPoint;

    private void Awake()
    {
        MainMenu += SubscribeAllEvent;
        CheckEvents(StateManager.Instance.state);
    }

    void SubscribeAllEvent()
    {
        // ýngame
        InGame += ObstacleManager.Instance.StartSpawnObstacle;
        InGame += UIManager.Instance.InGame;
        // end game
        EndGame += UIManager.Instance.EndGame;

        // game over
        GameOver += UIManager.Instance.GameOver;


        // point
        PlusPoint += GameManager.Instance.PlusPoint;
        PlusPoint += UIManager.Instance.UpdateScore;
    }


    public void CheckEvents(State state)
    {
        switch (state)
        {
            case State.MainMenu:
                MainMenu();
                break;
            case State.InGame:
                InGame();
                break;
            case State.GameOver:
                GameOver();
                break;
            case State.EndGame:
                EndGame();
                break;
            default:
                break;
        }
    }



}
