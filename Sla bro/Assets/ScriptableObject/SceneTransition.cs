using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName; // Nome da pr�xima cena
    public string nextSpawnPointName; // Nome do ponto de spawn na pr�xima cena
    public GameState gameState; // Refer�ncia ao ScriptableObject "GameState"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Atualiza o ponto de spawn no GameState
            gameState.NextSpawnPoint = nextSpawnPointName;
            Debug.Log($"Atualizando ponto de spawn para: {gameState.NextSpawnPoint}");

            // Carrega a pr�xima cena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
