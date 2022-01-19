using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleMovement : MonoBehaviour
{
    Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            _rigidbody.velocity = Vector3.back * 7;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishObstacle"))
        {
            gameObject.SetActive(false);
        }
    }

}
