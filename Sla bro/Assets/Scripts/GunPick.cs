using UnityEngine;

public class GunPick : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Voce esta colidindo");
        }
    }
}
