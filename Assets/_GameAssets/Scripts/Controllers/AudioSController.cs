using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSController : MonoBehaviour
{
    [SerializeField] private Ball _Ball;
    private const string _Tag1 = "Paddle";
    private const string _Tag2="Wall";
    [SerializeField] private AudioClip[] _sounds;
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();
    private void OnEnable()
    {
        if (_Ball == null) return;

        _Ball.OnColide -= Ball_OnColided;
        _Ball.OnColide += Ball_OnColided;
        _Ball.OnGoal -= Ball_OnGoals;
        _Ball.OnGoal += Ball_OnGoals;
    }
    private void OnDisable()
    {
        if (_Ball == null) return;

        _Ball.OnColide -= Ball_OnColided;
        _Ball.OnGoal -= Ball_OnGoals;
    }

    private void Ball_OnGoals(Side side)
    {
        PlaySfx(_sounds[^1]);
    }

    private void Ball_OnColided(string tag)
    {
        switch (tag)
        {
            case _Tag2:
                PlaySfx(_sounds[0]);
                break;
            case _Tag1:
                PlaySfx(_sounds[1]);
                break;
        }
    }
   private void PlaySfx(AudioClip clip) { _audioSource.PlayOneShot(clip); }
}
