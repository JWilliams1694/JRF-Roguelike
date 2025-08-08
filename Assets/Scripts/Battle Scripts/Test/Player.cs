using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private int energy;

    private SkillTree skillTree;

    void Start()
    {
        hp = maxHp = 100;
        energy = 4;
        skillTree = new SkillTree();
    }

    private void Update()
    {

    }

    public void SetName(string playerName)
    {
        name = playerName;
    }

    public void ShowStats()
    {
        Debug.Log($" | HP: {hp}/{maxHp} | Energy: {energy}");
    }

    public void LearnSkill()
    {
        skillTree.ChooseSkill();
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp < 0) hp = 0;
        Debug.Log($"{name} took {dmg} damage, HP now {hp}/{maxHp}");
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public int GetDamageOutput()
    {
        return 10 + tool.GetPower();
    }

    public int GetHP() { return hp; }
    public int GetMaxHP() { return maxHp; }
}
