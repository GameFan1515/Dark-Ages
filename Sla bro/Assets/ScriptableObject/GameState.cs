using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName ="ScriptableObjects/GameState")]
public class GameState : ScriptableObject
{
    public string LastSpawnPoint;
    public string NextSpawnPoint;
}
