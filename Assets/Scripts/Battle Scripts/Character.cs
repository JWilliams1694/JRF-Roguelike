using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public Stats stats; // Reference to the Stats ScriptableObject
    
    public int curr_health; // Current health of the character
    public int curr_energy; // Current energy of the character

    //
    public void takeDamage(int damage)
    {
        curr_health -= damage * (int)(0.1 * stats.defense);

        if (curr_health <= 0)
        {
            print("Dead!");
        }
    }

    public void basicAttack(Character recipient)
    {
        if (curr_energy <= 0)
        {
            print("Not enough energy to attack!");
            return; // Exit if not enough energy
        }
        int damage = 1 * stats.attack;
        recipient.takeDamage(damage);
        curr_energy -= 1; // Deduct energy for the attack
    }
}
