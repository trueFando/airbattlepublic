using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool HaveObstacle = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HaveObstacle = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HaveObstacle = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HaveObstacle = false;    
    }
}
