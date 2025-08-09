using UnityEngine;

public class Map : MonoBehaviour
{
    public CourseMap currentCourse;        // Assign in Inspector
    public Transform spawnPoint;           // Assign a spawn location in the scene

    private int floorLevel;

    private void Start()
    {
        floorLevel = 1;
    }

    public Enemy SpawnEnemy()
    {
        if (currentCourse.enemyPool == null || currentCourse.enemyPool.Count == 0)
        {
            Debug.LogWarning("No enemies in course's enemy pool.");
            return null;
        }

        // Choose a random EnemyData from the list
        EnemyData selectedData = currentCourse.enemyPool[Random.Range(0, currentCourse.enemyPool.Count)];

        // Instantiate the prefab
        GameObject enemyGO = Instantiate(selectedData.enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Initialize it using the EnemyData
        Enemy enemy = enemyGO.GetComponent<Enemy>();

        return enemy;
    }

    public bool AdvanceFloor()
    {
        if (floorLevel < currentCourse.totalFloors)
        {
            floorLevel++;
            return true;
        }
        return false;
    }

    public bool IsComplete() => floorLevel > currentCourse.totalFloors;
    public int GetCurrentFloor() => floorLevel;
    public int GetTotalFloors() => currentCourse.totalFloors;
    public string GetCourseName() => currentCourse.courseName;
}
