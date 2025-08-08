using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private int hp;
    private int energy;
    private SkillTree skillTree;

    void Start()
    {
        hp = playerData.maxHp;
        energy = playerData.startingEnergy;
        skillTree = new SkillTree();
    }

    public void ShowStats()
    {
        Debug.Log($" | HP: {hp}/{playerData.maxHp} | Energy: {energy}");
    }

    public void LearnSkill()
    {
        skillTree.ChooseSkill();
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp < 0) hp = 0;
        Debug.Log($"You took {dmg} damage, HP now {hp}/{playerData.maxHp}");
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public int GetDamageOutput()
    {
        return 10;
    }

    public int GetHP() { return hp; }
    public int GetMaxHP() { return playerData.maxHp; }

    public void AttackMenu()
    {

    }
}
