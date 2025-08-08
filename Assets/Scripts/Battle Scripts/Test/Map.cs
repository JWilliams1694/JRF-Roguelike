using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private string courseName;
    private int floorLevel;
    private int totalFloors;
    private List<Enemy> enemyPool;

    public Map(string courseName, int totalFloors)
    {
        this.courseName = courseName;
        this.totalFloors = totalFloors;
        this.floorLevel = 1;
        enemyPool = new List<Enemy>();

        InitializeEnemyPool();
    }

    private void InitializeEnemyPool()
    {
        if (courseName == "Math")
        {
            enemyPool.Add(new Enemy("Worksheet", courseName, 15, 15, 4));
            enemyPool.Add(new Enemy("Pop Quiz", courseName, 20, 20, 5));
            enemyPool.Add(new Enemy("Midterm", courseName, 30, 30, 6));
            enemyPool.Add(new Enemy("Final Exam", courseName, 50, 50, 8));
        }
        else if (courseName == "History")
        {
            enemyPool.Add(new Enemy("Essay", courseName, 18, 18, 5));
            enemyPool.Add(new Enemy("Reading Quiz", courseName, 22, 22, 6));
            enemyPool.Add(new Enemy("Group Presentation", courseName, 35, 35, 7));
            enemyPool.Add(new Enemy("Final Exam", courseName, 50, 50, 9));
        }
        else
        {
            enemyPool.Add(new Enemy("Generic Assignment", courseName, 10, 10, 3));
            enemyPool.Add(new Enemy("Lecture Notes", courseName, 15, 15, 4));
            enemyPool.Add(new Enemy("Final Exam", courseName, 50, 50, 8));
        }
    }

    public Enemy GenerateEnemy()
    {
        int index = Random.Range(0, enemyPool.Count);
        Enemy baseEnemy = enemyPool[index];
        return new Enemy(baseEnemy.GetName(), baseEnemy.GetCourse(), baseEnemy.GetHP(), baseEnemy.GetMaxHP(), baseEnemy.GetAttack());
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

    public bool IsComplete()
    {
        return floorLevel > totalFloors;
    }

    public string GetCourseName()
    {
        return courseName;
    }

    public int GetCurrentFloor()
    {
        return floorLevel;
    }

    public int GetTotalFloors()
    {
        return totalFloors;
    }
}
