using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    // Referência ao objeto que a câmera deve seguir (normalmente seu personagem)
    public Transform target;

    // Defina a distância vertical da câmera em relação ao personagem
    public float offsetY = 10f;

    // Velocidade com que a câmera segue o alvo
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Verifique se o alvo foi atribuído
        if (target == null)
        {
            Debug.LogError("Alvo da câmera não foi atribuído.");
            return;
        }

        // Posição desejada da câmera
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -offsetY);

        // Suavizando o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualizando a posição da câmera
        transform.position = smoothedPosition;
    }
}
