using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public GameEnding gameEnding;

    // Check whether if the player is in range of the observer
    private bool isPlayerInRange;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            // get the direction for the ray
            Vector3 direction = player.position - transform.position + Vector3.up;

            // Create a new ray
            Ray ray = new Ray(transform.position, direction);

            // get Raycast hit to know information about what the ray hit
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
