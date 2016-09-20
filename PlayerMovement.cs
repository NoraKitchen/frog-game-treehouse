using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator playerAnimator;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private float turningSpeed = 20f;
    private Rigidbody playerRigidbody;
    [SerializeField]
    private RandomSoundPlayer playerFootsteps;


	// Use this for initialization
	void Start () {
        //gets animator component from Player GameObject (frog)
        playerAnimator = GetComponent<Animator>();
        //get rigidbody component from player, this is used for rotation (at least here)
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //gets input from keyboard
        //will contain a -1 or +1 if the player pressed a key to move left or right?
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //combining them into one vector3 will let us move diagonally
        //y is up and down so it gets 0
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	}

    void FixedUpdate()
    {
        //if update has determined the player is pressing direction keys, animate
        if (movement != Vector3.zero)
        {
            //rotate frog in desired direction
            //creates a target rotation(direction we want frog to look to) based on the movement vector/direction
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            //move over time from current rotation to targetRotation
            Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);
            playerRigidbody.MoveRotation(newRotation);

            //movement animation only runs if 'speed' (a prop of the obj i assume) is above a certain #
            //SetFloat changes the speed - so this will trigger animation
            playerAnimator.SetFloat("Speed", 3f);

            //play footstep sounds
            playerFootsteps.enabled = true;
        } else
        {
            //if the player is no longer hitting directions, stop movement animation
            playerAnimator.SetFloat("Speed", 0f);
            //don't play footstep sounds
            playerFootsteps.enabled = false;
        }
    }
}
