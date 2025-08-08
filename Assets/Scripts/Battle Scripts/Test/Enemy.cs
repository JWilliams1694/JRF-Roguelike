using UnityEngine;

public class Enemy
{
    private string name;
    private string course;
    private int hp;
    private int maxHp;
    private int attack;
    private int rewardGold;

    public Enemy(string name, string course, int hp, int maxHp, int attack, int rewardGold)
    {
        this.name = name;
        this.course = course;
        this.hp = hp;
        this.maxHp = maxHp;
        this.attack = attack;
        this.rewardGold = rewardGold;
    }

    public string GetName() => name;
    public string GetCourse() => course;
    public int GetHP() => hp;
    public int GetMaxHP() => maxHp;
    public int GetAttack() => attack;
    public int GetRewardGold() => rewardGold;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp < 0) hp = 0;
        Debug.Log($"{name} took {dmg} damage, HP now {hp}/{maxHp}");
    }

    public bool IsAlive() => hp > 0;
}
