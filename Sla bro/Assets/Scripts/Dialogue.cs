using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isTyping; 
    private bool dialogueActive;

    public bool IsDialogueFinished => !dialogueActive; 

    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty; 
    }

    public void StartDialogue()
    {
        if (lines.Length == 0)
        {
            
            Debug.LogWarning("Nenhuma linha para exibir no diálogo!");
            return;
        }
        gameObject.SetActive(true);
        dialogueActive = true; 
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
        if (isTyping) 
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
        textComponent.text = string.Empty; 
        dialogueActive = false; 
        gameObject.SetActive(false);

    }
}
