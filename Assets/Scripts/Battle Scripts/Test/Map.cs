using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<EnemyData> enemyTypes; // Assign in inspector
    public Transform spawnPoint;

    private string courseName = "Math"; // example
    private int floorLevel;
    private int totalFloors = 5;

    private void Start()
    {
        floorLevel = 1;
    }

    public Enemy SpawnEnemy()
    {
        // Filter enemyTypes by courseName
        var validEnemies = enemyTypes.FindAll(e => e.courseName == courseName);
        if (validEnemies.Count == 0) return null;

        EnemyData selectedData = validEnemies[Random.Range(0, validEnemies.Count)];

        GameObject enemyObj = Instantiate(selectedData.enemyPrefab, spawnPoint.position, Quaternion.identity);
        Enemy enemyComponent = enemyObj.GetComponent<Enemy>();
        enemyComponent.Initialize(selectedData);

        return enemyComponent;
    }

    public bool AdvanceFloor()
    {
        if (floorLevel < totalFloors)
        {
            floorLevel++;
            return true;
        }
        return false;
    }

    public bool IsComplete() => floorLevel > totalFloors;
    public int GetCurrentFloor() => floorLevel;
    public int GetTotalFloors() => totalFloors;
}
