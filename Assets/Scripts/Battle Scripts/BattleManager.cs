using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    START,
    PLAYER_TURN,
    ENEMY_TURN,
    WON,
    LOST
}

public class BattleManager : MonoBehaviour
{
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerEntryPoint;
    public Transform enemyEntryPoint;

    public BattleState state;

    Unit playerUnit;
    Unit enemyUnit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;

        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerEntry = Instantiate(playerPrefab, playerEntryPoint);
        playerUnit = playerEntry.GetComponent<Unit>();
        playerHUD.SetHUD(playerUnit);

        GameObject enemyEntry = Instantiate(enemyPrefab, enemyEntryPoint);
        enemyUnit = enemyEntry.GetComponent<Unit>();
        enemyHUD.SetHUD(enemyUnit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
