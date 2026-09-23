using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text TLeft,TRight,StateT;
    [SerializeField] private Button TryB,MenuB;

    public void UpdateScore (Side _Side, ScoreController _Cls)
    {
        switch (_Side)
        {
            case Side.Left:
                TRight.text = _Cls.ScoreR.ToString();
                break;
            case Side.Right:
                TLeft.text = _Cls.ScoreL.ToString();
                break;
        }
    }
    public void ShowWiner(string StateTxt)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StateT.text = StateTxt;
        StateT.gameObject.SetActive(true);
        TryB.gameObject.SetActive(true);
        MenuB.gameObject.SetActive(true);
    }

    public void LoadScene(int id) { SceneManager.LoadScene(id, LoadSceneMode.Single); }
}
