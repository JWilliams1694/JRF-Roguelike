using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory
{
    private List<Item> items;
    private int maxSize;

    public Inventory(int size = 20)
    {
        maxSize = size;
        items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (items.Count >= maxSize)
        {
            Debug.Log("Your backpack is full!");
            return false;
        }
        items.Add(item);
        Debug.Log(item.Name + " was added to your inventory.");
        return true;
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            Debug.Log(items[index].Name + " was removed from your inventory.");
            items.RemoveAt(index);
        }
        else
        {
            Debug.Log("Invalid item index.");
        }
    }

    public void UseItem(int index, Player player)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].Use(player);
            if (items[index].Type == ItemType.Consumable)
            {
                RemoveItem(index);
            }
        }
        else
        {
            Debug.Log("Invalid item index.");
        }
    }

    public void ListItems()
    {
        if (items.Count == 0)
        {
            Debug.Log("Your inventory is empty.");
            return;
        }

        Debug.Log("Inventory:");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log((i + 1) + ". " + items[i].Name + " - " + items[i].Description);
        }
    }

    public Item GetItem(int index)
    {
        if (index >= 0 && index < items.Count)
            return items[index];
        return null;
    }

    public int GetSize()
    {
        return items.Count;
    }

    public int GetMaxSize()
    {
        return maxSize;
    }
}
