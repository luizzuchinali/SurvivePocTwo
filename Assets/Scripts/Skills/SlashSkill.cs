using UnityEngine;

public class SlashSkill : BaseSkill
{
    public float travelSpeed = 10f;

    public override void Update()
    {
        // transform.position += transform.forward * (travelSpeed * Time.deltaTime);

        base.Update();
    }
}