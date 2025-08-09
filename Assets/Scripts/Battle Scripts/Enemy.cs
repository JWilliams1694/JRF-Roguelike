using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public string enemyName;
    public string courseName;
    public int maxHP;
    public int currentHP;
    public int attackPower;

    private void Start()
    {
        // Optionally log spawn info
        Debug.Log($"Spawned enemy: {enemyName} | HP: {currentHP}/{maxHP} | ATK: {attackPower}");
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log($"{enemyName} took {amount} damage! Current HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public int GetAttackDamage()
    {
        return attackPower;
    }

    private void Die()
    {
        Debug.Log($"{enemyName} has been defeated!");
        // You could play an animation or effect here
        Destroy(gameObject);  // Remove from scene
    }

    public bool IsAlive() => currentHP > 0;

    public string GetName() => enemyName;
    public string GetCourse() => courseName;
    public int GetHP() => currentHP;
    public int GetMaxHP() => maxHP;
    public int GetAttack() => attackPower;
}
