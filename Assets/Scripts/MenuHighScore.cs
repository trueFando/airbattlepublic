using UnityEngine;
using UnityEngine.UI;

public class MenuHighScore : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("high").ToString();
    }
}
