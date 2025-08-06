using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    [SerializeField] public int max_health = 100; // Character's health
    [SerializeField] public int energy = 5; // Character's energy

    [SerializeField] public int attack = 10; // Character's attack power
    [SerializeField] public int defense = 5; // Player's defense power
}
