using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float bulletSpeed;
                     public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyTakeDamage Enemy = collision.gameObject.GetComponent<EnemyTakeDamage>();
            if (Enemy != null)
            {
                Enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

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
