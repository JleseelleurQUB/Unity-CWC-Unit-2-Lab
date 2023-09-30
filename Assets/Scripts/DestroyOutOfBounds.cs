using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys objects that leave the player's view
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } 
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }           

        // Reduces score when animals pass the player
            if (transform.position.z < lowerBound && DetectCollisions.lives > 0)
        {
            DetectCollisions.lives--;
            Debug.Log("Lives = " + DetectCollisions.lives);
        }
           
    }
}
