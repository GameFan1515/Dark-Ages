using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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