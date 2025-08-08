using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player
{
    private string name;
    private string playerMajor;
    private int hp;
    private int maxHp;
    private int energy;
    private int gold;

    private Equipment head;
    private Equipment body;
    private Equipment tool;

    private List<Item> inventory;
    private SkillTree skillTree;

    public Player()
    {
        name = "";
        playerMajor = "Undeclared";
        hp = maxHp = 100;
        energy = 3;
        gold = 0;
        inventory = new List<Item>();
        skillTree = new SkillTree();
        head = new Equipment();
        body = new Equipment();
        tool = new Equipment();
    }

    public void SetName(string playerName)
    {
        name = playerName;
    }

    public void ChooseMajor()
    {
        // For demo - random or default major
        // In Unity, replace with UI selection
        int choice = Random.Range(1, 4);
        switch (choice)
        {
            case 1:
                playerMajor = "Computer Science";
                break;
            case 2:
                playerMajor = "Biology";
                break;
            case 3:
                playerMajor = "Literature";
                break;
            default:
                playerMajor = "Undeclared";
                break;
        }
        Debug.Log($"Chosen Major: {playerMajor}");
    }

    public void ShowStats()
    {
        Debug.Log($"[{name}] Major: {playerMajor} | HP: {hp}/{maxHp} | Gold: {gold}");
    }

    public void EquipItem(Equipment equip)
    {
        switch (equip.GetSlot())
        {
            case Equipment.Slot.HEAD:
                head = equip;
                break;
            case Equipment.Slot.BODY:
                body = equip;
                break;
            case Equipment.Slot.TOOL:
                tool = equip;
                break;
        }
        Debug.Log($"Equipped: {equip.GetName()}");
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        Debug.Log($"Added {item.GetName()} to inventory.");
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= inventory.Count)
        {
            Debug.Log("Invalid item index.");
            return;
        }
        Item item = inventory[index];
        item.Use(this);
        if (item.GetType() == ItemType.Consumable)
        {
            inventory.RemoveAt(index);
        }
    }

    public void ShowInventory()
    {
        if (inventory.Count == 0)
        {
            Debug.Log("Inventory is empty.");
            return;
        }
        Debug.Log("Inventory:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log($"{i + 1}. {inventory[i].GetName()} - {inventory[i].GetDescription()}");
        }
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

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log($"{amount} gold added. Total gold: {gold}");
    }

    public string GetName() { return name; }
    public string GetMajor() { return playerMajor; }
    public int GetHP() { return hp; }
    public int GetMaxHP() { return maxHp; }
    public int GetGold() { return gold; }

    // Save/Load can use Unity's PlayerPrefs or file system - omitted for brevity
}
