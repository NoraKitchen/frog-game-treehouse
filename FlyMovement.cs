using UnityEngine;
using System.Collections;

public class FlyMovement : MonoBehaviour {

    [SerializeField]
    private Transform center;

    private float flySpeed;

    // Use this for initialization
    void Start () {

        //make the flies move at different speeds
        flySpeed = Random.Range(300f, 700f);
	
	}
	
	// Update is called once per frame
	void Update () {

        //note, to get transform of obj can just use 'transform' - don't need 'get component' cause unity knows all objs have transform
        transform.RotateAround(center.position, Vector3.up, flySpeed * Time.deltaTime);
        //transformvar.position gets its v3
	
	}
}
