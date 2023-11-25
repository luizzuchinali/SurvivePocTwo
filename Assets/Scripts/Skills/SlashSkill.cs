using System;
using UnityEngine;

public class SlashSkill : BaseSkill
{
    public float travelSpeed = 10f;

    private void Awake()
    {
        var system = GetComponent<ParticleSystem>();
        system.Stop();
        var systemMain = system.main;
        systemMain.duration = duration;
        // var particleSystems = GetComponentsInChildren<ParticleSystem>();
        // foreach (var particle in particleSystems)
        // {
        //     var main = particle.main;
        //     main.duration = duration;
        // }

        system.Play();
    }

    public override void Update()
    {
        transform.position += transform.forward * (travelSpeed * Time.deltaTime);

        base.Update();
    }
}