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

    
    void Start()
    {
       
        Destroy(gameObject, lifeTime);

    }

    
    void Update()
    {
       
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

   

}
