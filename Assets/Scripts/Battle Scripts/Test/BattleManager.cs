using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;// Assign in Inspector
    public CourseMap selectedMap; // Assign in Inspector
    private int currentFloor = 1;

    void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (player.IsAlive() && currentFloor <= selectedMap.totalFloors)
        {
            Debug.Log($"\n--- Course: {selectedMap.courseName} | Floor {currentFloor} ---");

            Enemy enemy = selectedMap.GenerateEnemy();

            yield return StartCoroutine(StartBattle(player, enemy));

            if (!player.IsAlive())
                break;

            currentFloor++;
            yield return new WaitForSeconds(1f);
        }

        Debug.Log(player.IsAlive() ? "\nYou passed the semester!" : "\nYou dropped out...");
    }

    private IEnumerator StartBattle(Player player, Enemy enemy)
    {
        Debug.Log($"You encounter a {enemy.GetName()} from {enemy.GetCourse()} class!");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Debug.Log($"\nPlayer HP: {player.GetHP()}/{player.GetMaxHP()} | Enemy HP: {enemy.GetHP()}/{enemy.GetMaxHP()}");

            Debug.Log("\n--- Player Turn ---");
            player.AttackMenu(); // Display options (text/UI)

            int choice = GetPlayerChoice();  // Simulate input
            yield return new WaitForSeconds(1f);  // simulate wait

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

            if (!enemy.IsAlive())
            {
                Debug.Log($"You defeated the {enemy.GetName()}!");
                yield break;
            }

            yield return new WaitForSeconds(1f);

            Debug.Log("\n--- Enemy Turn ---");
            int enemyDmg = enemy.GetAttack();
            player.TakeDamage(enemyDmg);
            Debug.Log($"{enemy.GetName()} dealt {enemyDmg} damage!");

            if (!player.IsAlive())
            {
                Debug.Log("You were defeated...");
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private int GetPlayerChoice()
    {
        // Replace with real UI input system
        return 1; // always choose basic attack for now
    }
}
