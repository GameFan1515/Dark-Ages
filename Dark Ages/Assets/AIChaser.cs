using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaser : MonoBehaviour
{

    public GameObject player; //é o objeto do player
    public float speed; // auto explicativo
    public float distanceBetween; // Varíavel pra ativar o Inimigo ao Chegar Perto
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // calcula a distância entre o player e o inimigo
        Vector2 direction = player.transform.position - transform.position; // Calcula a direção do movimento
        direction.Normalize(); // Normaliza a direção (magnitude 1)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //encontra o ângulo entre 2 pontos e converte de radian pra graus

        ;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Move o inimigo em direção ao jogador
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); // Rotaciona o inimigo para olhar para o jogador

        }
    }
}
