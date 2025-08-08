using UnityEngine;

public class BattleManager
{
    private Player player;
    private Enemy enemy;

    public BattleManager(Player player, Enemy enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public void StartBattle()
    {
        Debug.Log($"You encounter a {enemy.GetName()} from {enemy.GetCourse()} class!");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Debug.Log($"\nPlayer HP: {player.GetHP()}/{player.GetMaxHP()} | Enemy HP: {enemy.GetHP()}/{enemy.GetMaxHP()}");

            Debug.Log("\n--- Player Turn ---");
            player.AttackMenu();

            int choice = GetPlayerChoice();

            if (choice == 1)
            {
                int dmg = player.GetDamageOutput();
                enemy.TakeDamage(dmg);
                Debug.Log($"You dealt {dmg} damage to {enemy.GetName()}!");
            }
            else if (choice == 2)
            {
                int dmg = Mathf.RoundToInt(2.5f * player.GetDamageOutput());
                enemy.TakeDamage(dmg);
                Debug.Log($"You dealt {dmg} damage to {enemy.GetName()}!");
                player.TakeDamage(10);
                Debug.Log("You took 10 damage from your all-nighter!");
            }
            else if (choice == 3)
            {
                player.UseItem();
            }
            else
            {
                Debug.Log("Invalid choice. You lose your turn.");
            }

            if (!enemy.IsAlive())
            {
                Debug.Log($"You defeated the {enemy.GetName()}!");
                break;
            }

            Debug.Log("\n--- Enemy Turn ---");
            int enemyDmg = enemy.GetAttack();
            player.TakeDamage(enemyDmg);
            Debug.Log($"{enemy.GetName()} dealt {enemyDmg} damage!");

            if (!player.IsAlive())
            {
                Debug.Log("You were defeated...");
                break;
            }
        }
    }

    private int GetPlayerChoice()
    {
        // For Unity, replace this with your UI input system
        // For now, just simulate choice 1 for testing
        return 1;
    }
}
