using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName; 
    public string nextSpawnPointName; 
    public GameState gameState; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameState.NextSpawnPoint = nextSpawnPointName;
            Debug.Log($"Atualizando ponto de spawn para: {gameState.NextSpawnPoint}");

            
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
