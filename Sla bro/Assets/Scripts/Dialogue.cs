using UnityEngine;
using TMPro;
using System.Collections;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public bool DialogueFinished;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
    }
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.E)) 

            {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                
                StopAllCoroutines();
                textComponent.text = lines[index];
            }   
        }
    }
     public void StartDialogue()
    {
        gameObject.SetActive(true);
        DialogueFinished = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            DialogueFinished = false;
        }
        else
        {
            DialogueFinished = true;
            gameObject.SetActive(false);
        }
    }
}
