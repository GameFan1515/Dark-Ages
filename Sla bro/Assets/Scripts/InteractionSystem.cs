using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public GameObject e;
    public Dialogue dialogue;
    [SerializeField] GameObject Gun;

    private bool isColliding;

    private void Start()
    {
        
        e.SetActive(false); // Indicador de interação desativado inicialmente
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.IsDialogueFinished)
            {
                dialogue.StartDialogue(); // Inicia o diálogo
               
            }
            else
            {
                dialogue.NextLine(); // Avança para a próxima linha
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {
            e.SetActive(true); // Mostra o indicador de interação
            isColliding = true;
        }

        if (collision.gameObject.tag == "Gun")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Gun.SetActive(true);
            }

        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {

            e.SetActive(false); // Esconde o indicador de interação
            dialogue.gameObject.SetActive(false);
            isColliding = false;

        }
    }
}