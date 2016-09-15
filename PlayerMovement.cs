using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator playerAnimator;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

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
            //movement animation only runs if 'speed' (a prop of the obj i assume) is above a certain #
            //SetFloat changes the speed - so this will trigger animation
            playerAnimator.SetFloat("Speed", 3f);
        } else
        {
            //if the player is no longer hitting directions, stop movement animation
            playerAnimator.SetFloat("Speed", 0f);
        }
    }
}
