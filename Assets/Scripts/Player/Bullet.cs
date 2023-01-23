using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp;
        if (collision.TryGetComponent(out hp))
        {
            hp.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
