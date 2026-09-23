using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int ScoreL {  get; private set; }
    public int ScoreR {  get; private set; }

    private readonly int WinScore = 11;

    public bool IsWin() => ScoreL == WinScore || ScoreR == WinScore;
    public string Winside() => ScoreL >= WinScore ? "Player Won :)" : "Player Lost :(";

    public void IncreaseSide(Side _side)
    {
        switch (_side)
        {
            case Side.Left:
                ScoreR++;
                break;
            case Side.Right:
                ScoreL++;
                break;
            default:
                break;
        }
    }
}
