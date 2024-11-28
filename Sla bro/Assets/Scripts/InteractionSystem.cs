using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public GameObject e;
    public GameObject Player;
    private bool isColliding;
    public Dialogue Dialogue;
    public TextMeshProUGUI Text;
    private void Start()
    {
        Dialogue.gameObject.SetActive(false);
        e.SetActive(false);
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (Dialogue.DialogueFinished)
            {

                Dialogue.StartDialogue();
                Dialogue.textComponent.text = string.Empty;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag ("Mail"))
        {
            e.SetActive(true);
            isColliding = true;
            Debug.Log("Player is Colliding");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {
            e.SetActive(false);
            isColliding = false;
            
            Debug.Log("Player is not Colliding");

        }
    }
}
