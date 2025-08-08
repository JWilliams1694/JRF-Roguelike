using UnityEngine;

public class Equipment
{
    public enum Slot
    {
        Head,
        Body,
        Tool
    }

    public string Name { get; private set; }
    public Slot EquipSlot { get; private set; }
    public int Power { get; private set; }

    public Equipment(string name, Slot slot, int power)
    {
        Name = name;
        EquipSlot = slot;
        Power = power;
    }

    // Default constructor for "None" equipment
    public Equipment()
    {
        Name = "None";
        EquipSlot = Slot.Tool;
        Power = 0;
    }
}
