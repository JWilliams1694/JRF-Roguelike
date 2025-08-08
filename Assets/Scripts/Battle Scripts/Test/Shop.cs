using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop
{
    private List<Item> stock;

    public Shop()
    {
        stock = new List<Item>
        {
            new Item("Energy Drink", "Restores energy for studying.", 10, ItemType.Consumable),
            new Item("Notebook", "Increases study effectiveness.", 15, ItemType.Equipment),
            new Item("Calculator", "Helps with math courses.", 20, ItemType.Equipment)
        };
    }

    public void DisplayItems()
    {
        Debug.Log("Shop Items:");
        for (int i = 0; i < stock.Count; i++)
        {
            Debug.Log($"{i + 1}. {stock[i].Name} - ${stock[i].Value}");
        }
    }

    public void BuyItem(Player player, int choice)
    {
        if (choice <= 0 || choice > stock.Count)
        {
            Debug.Log("Purchase cancelled.");
            return;
        }

        Item item = stock[choice - 1];

        if (player.Gold >= item.Value)
        {
            player.AddGold(-item.Value);
            player.AddItem(item);
            Debug.Log($"You bought {item.Name}!");
        }
        else
        {
            Debug.Log("Not enough gold.");
        }
    }
}
