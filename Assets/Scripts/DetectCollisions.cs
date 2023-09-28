using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Destroys projectiles and animals upon collision
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
