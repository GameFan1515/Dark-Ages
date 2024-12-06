using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public GameObject e;
    public Dialogue dialogue;
    [SerializeField] GameObject Gun;

    private bool isColliding;

    private void Start()
    {
        
        e.SetActive(false); 
    }

    private void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue.IsDialogueFinished)
            {
                dialogue.StartDialogue(); 
               
            }
            else
            {
                dialogue.NextLine(); 
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mail"))
        {
            e.SetActive(true); 
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

            e.SetActive(false); 
            dialogue.gameObject.SetActive(false);
            isColliding = false;

        }
    }
}