using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isTyping; // Flag para controlar se o texto está sendo digitado
    private bool dialogueActive;

    public bool IsDialogueFinished => !dialogueActive; // Propriedade para verificar o estado

    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty; // Inicializa o texto vazio
    }

    public void StartDialogue()
    {
        if (lines.Length == 0)
        {
            
            Debug.LogWarning("Nenhuma linha para exibir no diálogo!");
            return;
        }
        gameObject.SetActive(true);
        dialogueActive = true; // Inicia o diálogo
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        if (isTyping) // Completa a linha atual se ainda está digitando
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
            isTyping = false;
        }
        else if (index < lines.Length - 1)
        {
            gameObject.SetActive(true);
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        textComponent.text = string.Empty; // Limpa o texto
        dialogueActive = false; // Marca o fim do diálogo
        gameObject.SetActive(false);

    }
}
