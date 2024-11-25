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
            LevelLoader loader = FindObjectOfType<LevelLoader>(); //Procura em todos os Objetos o Script levelLoader e Retorna ele como loader
            loader.LoadEspecificLevel(levelToLoad); //Acessa e Utiliza o Método LoadNextLevel do Script
        }

    }

}
