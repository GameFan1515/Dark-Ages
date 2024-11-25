using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameState gameState; // Refer�ncia ao ScriptableObject "GameState"

   
    void Start()
    {
        // Se NextSpawnPoint estiver vazio ou nulo, define como Bed_Spawn
        if (string.IsNullOrEmpty(gameState.NextSpawnPoint))
        {
            gameState.NextSpawnPoint = "Bed_Spawn"; // Define o spawn inicial
        }

        // Verifica o pr�ximo ponto de spawn definido no GameState
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
                    Debug.LogError("Player n�o encontrado! Certifique-se de que o Player tenha a tag 'Player'.");
                }
            }
            else
            {
                Debug.LogError($"Ponto de Spawn '{spawnPointName}' n�o encontrado na cena!");
            }
        }
        else
        {
            Debug.LogError("O campo 'NextSpawnPoint' no GameState est� vazio ou nulo!");
        }
    }
}
