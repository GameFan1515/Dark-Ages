using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    // Refer�ncia ao objeto que a c�mera deve seguir (normalmente seu personagem)
    public Transform target;

    // Defina a dist�ncia vertical da c�mera em rela��o ao personagem
    public float offsetY = 10f;

    // Velocidade com que a c�mera segue o alvo
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Verifique se o alvo foi atribu�do
        if (target == null)
        {
            Debug.LogError("Alvo da c�mera n�o foi atribu�do.");
            return;
        }

        // Posi��o desejada da c�mera
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -offsetY);

        // Suavizando o movimento da c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualizando a posi��o da c�mera
        transform.position = smoothedPosition;
    }
}
