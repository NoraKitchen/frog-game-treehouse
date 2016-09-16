using UnityEngine;
using System.Collections;

public class PickupParticlesDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //destroy the picup particles after 5 secs
        Destroy(gameObject, 5f);
	}
	
}
