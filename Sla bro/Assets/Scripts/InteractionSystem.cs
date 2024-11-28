using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public GameObject e;
    public Dialogue dialogue;

    private bool isColliding;

    private void Start()
    {
        e.SetActive(false); // Indicador de intera��o desativado inicialmente
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.IsDialogueFinished)
            {
                dialogue.StartDialogue(); // Inicia o di�logo
            }
            else
            {
                dialogue.NextLine(); // Avan�a para a pr�xima linha
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {
            e.SetActive(true); // Mostra o indicador de intera��o
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {

            e.SetActive(false); // Esconde o indicador de intera��o
            dialogue.gameObject.SetActive(false);
            isColliding = false;
            
        }
    }
}