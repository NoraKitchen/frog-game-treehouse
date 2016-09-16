using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

    [SerializeField]
    private GameObject pickupPrefab;

    void OnTriggerEnter(Collider other) {
        //other is a naming convention for OnTriggerEnter, cause it makes it clear it's not THIS game obj

        if (other.CompareTag("Player"))
            //so if the thing that collided with it is tagged "Player"--tag is just a thing you can set in unity inspector
        {
               //magic dust
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            //kill fly
            Destroy(gameObject);
        }
    }
}
