using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPHelper : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
