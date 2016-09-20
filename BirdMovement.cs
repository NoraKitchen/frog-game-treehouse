using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    [SerializeField]
    private Transform target;

    private NavMeshAgent birdAgent;

    private Animator birdAnimator;

    [SerializeField]
    private RandomSoundPlayer birdFootsteps;


    // Use this for initialization
    void Start () {
        birdAgent = GetComponent<NavMeshAgent>();
        birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //tell bird what to follow
        birdAgent.SetDestination(target.position);

        //measure magnitude of navmehsagent's velocity
        float speed = birdAgent.velocity.magnitude;

        //pass speed to animator so it knows to animate bird
        birdAnimator.SetFloat("Speed", speed);


        if (speed > 0)
        {
            birdFootsteps.enabled = true;
        }
        else
        {
            birdFootsteps.enabled = false;
        }
	
	}
}
