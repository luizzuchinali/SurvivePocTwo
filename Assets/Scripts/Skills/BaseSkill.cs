using System;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown = 1f;
    public float nextLaunchTime = 0;
    public float duration = 1f;

    public abstract void Launch(Vector3 origin, Vector3 targetDirection);
}