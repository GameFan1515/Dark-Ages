using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EspecificLevelCollisionTrigger : MonoBehaviour
{
  
    public int levelToLoad;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            LevelLoader loader = FindObjectOfType<LevelLoader>();
            loader.LoadEspecificLevel(levelToLoad); 
        }

    }

}
