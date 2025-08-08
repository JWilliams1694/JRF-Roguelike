using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHp = 100;
    public int startingEnergy = 4;

    [SerializeField] public int attack = 10; // Character's attack power
    [SerializeField] public int defense = 5; // Player's defense power
}
