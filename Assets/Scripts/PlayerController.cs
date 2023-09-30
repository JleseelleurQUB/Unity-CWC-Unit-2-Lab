using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float zRangeUpper = 3.0f;
    public float zRangeLower = -1.0f;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Limits player movement to within a given range on the x and z axes
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zRangeLower)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeLower);
        }

        if (transform.position.z > zRangeUpper)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUpper);
        }
        
        // Moves the player based on left/right up/down inputs
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launches a projectile from the player
            Vector3 projectileSpawnPos = transform.position + new Vector3(0, 0, 2);
            Instantiate(projectilePrefab, projectileSpawnPos, projectilePrefab.transform.rotation);
        }
    }
}
