using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    // static allows variable to be accessed by other scripts
    public static int score = 0;
    public static int lives = 3;
    // slider UI element to track animal health
    public Slider slider;
    public int health;

    // Sets slider max and current value for each type of animal upon spawning
    private void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Destroys projectiles and animals upon collision, reduces/increases player lives/score based on what is colliding. Name may be used as identifier, or general tags assigned via inspector
        
        if (other.gameObject.name == "Player" && lives > 0)
        {
            lives--;
            Destroy(gameObject);
            Debug.Log("Lives = " + lives);
        }

        else if (other.gameObject.tag != "Player")
        {
            slider.value--;
            Destroy(other.gameObject);
            // If health slider is at 0, animal is destroyed by collision and score increases
            if (slider.value < 1)
            {
                score++;
                Destroy(gameObject);
                Debug.Log("Score = " + score);
            }
        }

      
    }

    private void Update()
    {
        if (lives == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
