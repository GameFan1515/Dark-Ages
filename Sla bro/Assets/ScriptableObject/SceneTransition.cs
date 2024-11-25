using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName; // Nome da próxima cena
    public string nextSpawnPointName; // Nome do ponto de spawn na próxima cena
    public GameState gameState; // Referência ao ScriptableObject "GameState"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Atualiza o ponto de spawn no GameState
            gameState.NextSpawnPoint = nextSpawnPointName;
            Debug.Log($"Atualizando ponto de spawn para: {gameState.NextSpawnPoint}");

            // Carrega a próxima cena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
