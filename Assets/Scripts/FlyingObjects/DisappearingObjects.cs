using UnityEngine;

public class DisappearingObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Deadzone>() != null)
        {
            if (GetComponent<Health>() != null)
            {
                GetComponent<Health>().Die();
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
