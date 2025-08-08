using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    private int currentHP;

    public void Initialize(EnemyData enemyData)
    {
        data = enemyData;
        currentHP = data.maxHP;
        gameObject.name = data.enemyName;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;
    }

    public bool IsAlive() => currentHP > 0;

    public string GetName() => data.enemyName;
    public string GetCourse() => data.courseName;
    public int GetHP() => currentHP;
    public int GetMaxHP() => data.maxHP;
    public int GetAttack() => data.attackPower;
}
