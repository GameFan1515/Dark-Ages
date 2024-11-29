using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destrói o Projétil
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimenta a Bala
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
}
