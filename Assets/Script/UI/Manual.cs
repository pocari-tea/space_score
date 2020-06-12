using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manual : MonoBehaviour
{
    public void ShowManual()
    {
        SceneManager.LoadScene("Manual");
    }
}
