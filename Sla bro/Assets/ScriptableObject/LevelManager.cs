using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameState gameState; // Referência ao ScriptableObject "GameState"

   
    void Start()
    {
        
        
        if (string.IsNullOrEmpty(gameState.NextSpawnPoint))
        {
            gameState.NextSpawnPoint = "Bed_Spawn"; 
        }
       
        string spawnPointName = gameState.NextSpawnPoint;

        if (!string.IsNullOrEmpty(spawnPointName))
        {
            GameObject spawnPoint = GameObject.Find(spawnPointName);
            if (spawnPoint != null)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    player.transform.position = spawnPoint.transform.position;
                    Debug.Log($"Player posicionado em: {spawnPointName}");
                }
                
            }
           
        }
        
    }
}
