using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float healthAmount = 100f; // A Vida do Personagem
    public Image Pixel_Blood; // Refer�cia da Imagem da Vinheta de Sangue
    private float opacityLevel = 0f; // N�vel de Opacidade

    private void Start()
    {
        SetOpacity(0f); // Pra que a Vinheta N�o comece j� aparecendo
    }


    void Update()
    {
        if (healthAmount <= 0) // Se a Vida for igual ou Menor a 0
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Pega a Cena Pelo Nome e a Reinicia
        }
        if (Input.GetMouseButtonDown(0)) // Se o Bot�o Esquerdo do Mouse for Pressionado
        {
            TakeDamage(20); // Roda o M�todo pra Tirar 20 da Vida do Personagem
        }
        if (Input.GetMouseButtonDown(1)) // Se o Bot�o Direito do Mouse for Pressionado
        {
            HealDamage(20); // Roda o M�todo pra Curar 20 da Vida do Personagem
        }
    }


    public void TakeDamage(float damage) // M�todo pra Tomar Dano com o Par�metro Sendo o Quanto de Vida Deve ser Retirada 
    {
        healthAmount -= damage; // Retira da Vida o valor de "damage"
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); //Garante que a Vida n�o Possa ser Menor que 0 Nem Maior que 100
        UpdateDamageVignette(); // Roda o M�todo pra Aumentar a Opacidade da Vinheta
    }

    public void HealDamage(float damage) // M�todo pra Curar Vida com o Par�metro Sendo o Quanto de Vida Deve ser Acrescentada 
    {
        healthAmount += damage; // Acrescenta Vida ao Player com o Valor de "damage"
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); // Garante que a Vida n�o Possa ser Menor que 0 Nem Maior que 100
        UpdateDamageVignette(); // Roda o M�todo pra Diminuir a Opacidade da Vinheta
    }

    private void UpdateDamageVignette() // Atualiza a Opacidade da Vi+nheta
    {
        opacityLevel = Mathf.Clamp01(1 - healthAmount / 100f); // Atualiza a Opacidade de Acordo com a Quantidade de Vida
        Color color = Pixel_Blood.color; // Recebe o Valor Color da Imagem e passa para a vari�vel "color"
        color.a = opacityLevel; // O Alpha "Opacidade" Ser� o Valor que Estiver em "opacityLevel"
        Pixel_Blood.color = color; // Atualiza a Nova Opacidade da Imagem
    }

    private void SetOpacity(float opacity) //Serve pra Que a Vinheta n�o Apare�a ao Iniciar
    {
        Color color = Pixel_Blood.color; //Recebe o Valor Color da Imagem e passa para a vari�vel "color"
        color.a = opacity; //O Alpha "Opacidade" Ser� o Par�metro "opacity"
        Pixel_Blood.color = color; // Atualiza a Nova Opacidade da Imagem
    }

}
