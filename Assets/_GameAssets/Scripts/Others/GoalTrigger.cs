using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour,IGoal
{
    [SerializeField] private Side _Side;
    public Side Getside() => _Side;
}