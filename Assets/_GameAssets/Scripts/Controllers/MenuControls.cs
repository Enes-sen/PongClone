using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayB()
    {
        Debug.Log("Loading Scene:" +1.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    public void CloseGame() { Debug.Log("Test"); Application.Quit(); }
}
