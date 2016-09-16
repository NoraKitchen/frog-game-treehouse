using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private Transform player;
    //below is v3 var to record camera offset from player
    [SerializeField]
    private Vector3 offset;
    private float cameraFollowSpeed = 5f;

	// Use this for initialization
    //void Start () {
	
    //}
    //don't actually need start here since we exposed our vars so we put them in through Unity editor and don't need to initalize here
	
	// Update is called once per frame
	void Update () {
        //store the position the camera should move toward
        //will consider player position, but keep the camera offset by the defined amounts
        Vector3 newPosition = player.position + offset;

        //takes the position of the camera (transform.position)
        //lerps/slowly animates it between v3position to desired v3position
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
	}
}
