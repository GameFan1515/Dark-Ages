using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NextLevelCollisionTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelLoader loader = FindObjectOfType<LevelLoader>(); //Procura em todos os Objetos o Script levelLoader e Retorna ele como loader
            loader.LoadNextLevel(); //Acessa e Utiliza o Método LoadNextLevel do Script
        }

    }

}
