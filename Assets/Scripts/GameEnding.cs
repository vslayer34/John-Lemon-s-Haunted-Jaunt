using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    // the fading out duration of the endgame image and the time to display the end game image
    [SerializeField]
    private float fadeDuration = 1.0f;
    private float displayImageDuration = 1.0f;

    // the player Gameobject
    [SerializeField]
    private GameObject player;

    // referance to the end game and get caught canvas group
    [SerializeField]
    private CanvasGroup endGameUICanvasGroup;
    [SerializeField]
    private CanvasGroup geCaughtUICanvasGroup;

    // bool to determine player stauts in the game
    private bool didPlayerReachExit;
    private bool didPlayerGetCaught;

    // calculate time for displaying Win/Gameover UI messages
    private float timer;

    // Audio Setup
    [SerializeField]
    private AudioSource escapeAudio;

    [SerializeField]
    private AudioSource caughtAudio;

    private bool hasAudioPlayed;

    void Update()
    {
        if (didPlayerReachExit)
        {
            EndLevel(endGameUICanvasGroup, false, escapeAudio);
        }
        else if (didPlayerGetCaught)
        {
            EndLevel(geCaughtUICanvasGroup, true, caughtAudio);
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

    void EndLevel(CanvasGroup canvasGroup, bool Restart, AudioSource audioSource)
    {
        // Play the audio once when the method is called
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        // how much time then the player ended the level
        timer += Time.deltaTime;
        
        // increase the alpha with time
        canvasGroup.alpha = timer / fadeDuration;


        // display the image before restarting or exiting the game
        if (timer > fadeDuration + displayImageDuration)
        {
            if (Restart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    // set the didPlayerGetCaught to true in case the player is caught
    public void CaughtPlayer()
    {
        didPlayerGetCaught = true;
    }
}
