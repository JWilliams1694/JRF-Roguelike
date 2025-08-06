using UnityEngine;

public class Player : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curr_health = stats.max_health; // Initialize current health to max health
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the enemy exists in the scene before performing an attack
            basicAttack(GameObject.Find("Enemy").GetComponent<Character>()); // Perform a basic attack on the enemy
            Debug.Log("attack");
        }
    }
}
