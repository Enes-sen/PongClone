using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Text TLeft,TRight,StateT;
    [SerializeField] private Button TryB,MenuB;
    [Header("Sfx Settings")]
    [SerializeField] private AudioSource _Audiosource;
    [SerializeField] private AudioClip SoundClip;

    private void Start()
    {
        TryB.onClick.AddListener(LoadSceneTry);
        MenuB.onClick.AddListener(LoadSceneMenu);
    }
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
    private void LoadSceneTry() { StartCoroutine(SceneLoader(0,0.1f)); }
    private void LoadSceneMenu() { StartCoroutine(SceneLoader(1,0.1f)); }
    private IEnumerator SceneLoader( int id ,float time)
    {

        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(id, LoadSceneMode.Single);
    }
}
