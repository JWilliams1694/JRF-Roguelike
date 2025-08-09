using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSO", menuName = "Scriptable Objects/Course Map")]
public class CourseMap : ScriptableObject
{
    public string courseName;
    public int totalFloors;
    public List<EnemyData> enemyPool;  // Populate this in the Inspector
}
