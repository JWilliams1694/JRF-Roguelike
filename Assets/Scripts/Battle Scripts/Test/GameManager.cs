using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Map gameMap;
    private Shop shop;

    void Start()
    {
        player = new Player();
        shop = new Shop();

        // For demo, set player name and choose major via code or UI
        player.SetName("Student");
        player.ChooseMajor();

        // Choose course / dungeon - for demo just Math with 4 floors
        gameMap = new Map("Math", 4);

        StartCoroutine(GameLoop());
    }

    private System.Collections.IEnumerator GameLoop()
    {
        while (player.IsAlive() && !gameMap.IsComplete())
        {
            Debug.Log($"\n--- Entering Course: {gameMap.GetCourseName()} Floor {gameMap.GetCurrentFloor()} ---");

            Enemy enemy = gameMap.GenerateEnemy();
            BattleManager battle = new BattleManager(player, enemy);
            battle.StartBattle();

            if (!player.IsAlive())
                break;

            player.AddGold(10);

            // Let player use items or buy from shop via UI, here simplified
            player.ShowInventory();
            // Example: player.UseItem() would be called from UI

            // Example buying from shop - simulate choice 1
            shop.DisplayItems();
            shop.BuyItem(player, 1);

            gameMap.AdvanceFloor();

            yield return null;  // wait a frame, replace with UI wait in real game
        }

        Debug.Log(player.IsAlive() ? "\nYou passed the semester!" : "\nYou dropped out...");

        player.Save("savefile.txt");
    }
}
