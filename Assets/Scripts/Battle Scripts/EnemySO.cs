using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string courseName;
    public int maxHP;
    public int attackPower;
    public GameObject enemyPrefab;  // Assign prefab in inspector
}
