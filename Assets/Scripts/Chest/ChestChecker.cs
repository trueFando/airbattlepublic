using UnityEngine;

public class ChestChecker : MonoBehaviour
{
    [SerializeField] private GameObject _chestCanvas;

    private void Start()
    {
        if (PlayerPrefs.GetInt("firstRun") == 0)
        {
            _chestCanvas.SetActive(true);
            PlayerPrefs.SetInt("firstRun", 1);
        }
        else
        {
            Destroy(_chestCanvas);
            Destroy(gameObject);
        }
    }
}
