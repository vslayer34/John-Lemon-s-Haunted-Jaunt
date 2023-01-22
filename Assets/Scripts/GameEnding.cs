using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    // the fading out duration of the endgame image and the time to display the end game image
    [SerializeField]
    private float fadeDuration = 1.0f;
    private float displayImageDuration = 1.0f;

    // the player Gameobject
    [SerializeField]
    private GameObject player;

    // referance to the canvas group
    [SerializeField]
    private CanvasGroup endGameUICanvasGroup;

    private bool didPlayerReachExit;
    private float timer;


    void Update()
    {
        if (didPlayerReachExit)
        {
            EndLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the gameobject that triggered the collider is the player
        if (other.gameObject == player)
        {
            // set to didPlayerReachExit to true
            didPlayerReachExit = true;
        }
    }

    void EndLevel()
    {
        // how much time then the player ended the level
        timer += Time.deltaTime;

        // increase the alpha with time
        endGameUICanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
            Application.Quit();
    }
}
