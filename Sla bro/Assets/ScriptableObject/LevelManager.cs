using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameState gameState; // Referência ao ScriptableObject "GameState"

   
    void Start()
    {
        // Se NextSpawnPoint estiver vazio ou nulo, define como Bed_Spawn
        if (string.IsNullOrEmpty(gameState.NextSpawnPoint))
        {
            gameState.NextSpawnPoint = "Bed_Spawn"; // Define o spawn inicial
        }

        // Verifica o próximo ponto de spawn definido no GameState
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
                else
                {
                    Debug.LogError("Player não encontrado! Certifique-se de que o Player tenha a tag 'Player'.");
                }
            }
            else
            {
                Debug.LogError($"Ponto de Spawn '{spawnPointName}' não encontrado na cena!");
            }
        }
        else
        {
            Debug.LogError("O campo 'NextSpawnPoint' no GameState está vazio ou nulo!");
        }
    }
}
