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

    public void LoadNextLevel() //M�todo pra ir pra Pr�xima Cena
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); //Roda o M�todo LoadLevel com o Par�metro que Identifica sua Cena Atual e Passa pra Pr�xima (lembrar Sempre de usar StartCoroutine ao Acessar um M�todo do Mesmo)

    }

    public void LoadEspecificLevel(int levelindex)
    {
        StartCoroutine(LoadLevel(levelindex)); //Roda o M�todo LoadLevel que � Utilizado no Script "EspecificLevelCollisionTrigger" Pra Escolher pra Qual Cena Vai (lembrar Sempre de usar StartCoroutine ao Acessar um M�todo do Mesmo)
    }

    IEnumerator LoadLevel(int levelIndex) //Utilizado pra quando Precisamos que o C�digo tenha um Delay antes de Rodar (Coroutine)
    {
        transition.SetTrigger("Start"); //Roda a Anima��o

        yield return new WaitForSeconds(transitionTime); //Espera um Tempo pra que a Anima��o Rode

        SceneManager.LoadScene(levelIndex); //Te Manda pra Pr�xima Cena
    }

}
