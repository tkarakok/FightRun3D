using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            EventManager.Instance.CheckEvents(StateManager.Instance.state = State.GameOver);
        }
        else if (other.CompareTag("Point"))
        {
            EventManager.Instance.PlusPoint();
        }
    }
}
