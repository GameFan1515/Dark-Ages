using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy.SetActive(true);          
        }
        
       
    }
}
