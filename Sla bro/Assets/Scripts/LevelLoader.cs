using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Permite acessar o Scene Manager

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
  
    void Update()
    {

    }

    public void LoadNextLevel() //Método pra ir pra Próxima Cena
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); //Roda o Método LoadLevel com o Parâmetro que Identifica sua Cena Atual e Passa pra Próxima (lembrar Sempre de usar StartCoroutine ao Acessar um Método do Mesmo)

    }

    public void LoadEspecificLevel(int levelindex)
    {
        StartCoroutine(LoadLevel(levelindex)); //Roda o Método LoadLevel que é Utilizado no Script "EspecificLevelCollisionTrigger" Pra Escolher pra Qual Cena Vai (lembrar Sempre de usar StartCoroutine ao Acessar um Método do Mesmo)
    }

    IEnumerator LoadLevel(int levelIndex) //Utilizado pra quando Precisamos que o Código tenha um Delay antes de Rodar (Coroutine)
    {
        transition.SetTrigger("Start"); //Roda a Animação

        yield return new WaitForSeconds(transitionTime); //Espera um Tempo pra que a Animação Rode

        SceneManager.LoadScene(levelIndex); //Te Manda pra Próxima Cena
    }

}
