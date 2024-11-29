using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;


    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        //Rota��o 
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //Posi��o
        Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDir.z = 0;
        transform.position = player.position + (offset * playerToMouseDir.normalized);

        //Girar 
        Vector3 localScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }
        transform.localScale = localScale;
    }
}
