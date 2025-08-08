using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Map gameMap;

    void Start()
    {
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

            gameMap.AdvanceFloor();

            yield return null;  // wait a frame, replace with UI wait in real game
        }

        Debug.Log(player.IsAlive() ? "\nYou passed the semester!" : "\nYou dropped out...");
    }
}
