using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    public void ChangeToScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
