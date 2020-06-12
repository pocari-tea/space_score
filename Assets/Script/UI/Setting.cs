using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public void GoSetting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Setting");
        }
    }
}
