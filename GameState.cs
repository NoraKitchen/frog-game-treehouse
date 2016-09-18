using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    private bool gameStarted = false;
    [SerializeField]
    private Text gameStartedText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BirdMovement birdMovement;
    [SerializeField]
    private FollowCamera followCamera;
    private float restartDelay = 3f;
    private float restartTimer;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();

        //prevent player from moving at start
        playerMovement.enabled = false;
        birdMovement.enabled = false;

        //prevent followcamera fro mmoving to start position
        followCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameStarted == false && Input.GetKeyUp(KeyCode.Space))
        {
            StartGame();
        }

        if (playerHealth.alive == false)
        {
            EndGame();

            //increment a timer to count up to restarting
            //remember time.deltaTime is time between now and last frame, so basically increments the timer ever frame
            restartTimer = restartTimer + Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                //reload curreently loaded level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
	}

    private void StartGame()
    {
        gameStarted = true;
        gameStartedText.color = Color.clear;
        playerMovement.enabled = true;
        birdMovement.enabled = true;
        followCamera.enabled = true;
    }

    private void EndGame()
    {
        gameStarted = false;
        gameStartedText.color = Color.white;
        gameStartedText.text = "Game Over!";

        //remove player from screen
        player.SetActive(false);
    }
}
