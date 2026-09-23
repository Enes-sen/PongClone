using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuControls : MonoBehaviour
{
    [Header("buttons")]
    [SerializeField] private Button playB,closeB;
    [Header("Sfx Settings")]
    [SerializeField] private AudioSource _Audiosource;
    [SerializeField] private AudioClip SoundClip;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playB.onClick.AddListener(PlayGame);
        closeB.onClick.AddListener(CloseGame);

    }
    private void PlayGame()
    {
        StartCoroutine(PlayGameC(0.1f));
    }

    private IEnumerator PlayGameC(float time)
    {
        _Audiosource.PlayOneShot(SoundClip);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    private IEnumerator CloseGameC(float time)
    {
        _Audiosource.PlayOneShot(SoundClip);
        yield return new WaitForSeconds(time);
        Application.Quit();
    }

    private void CloseGame() { StartCoroutine(CloseGameC(0.1f)); }
}
