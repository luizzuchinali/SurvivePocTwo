using UnityEngine;


public class SlashSkill : BaseSkill
{
    public float travelTime = 0.5f;
    public float travelSpeed = 10f;

    public override void Launch(Vector3 origin, Vector3 targetDirection)
    {
        if (nextLaunchTime >= Time.time)
            return;

        transform.rotation = Quaternion.LookRotation(
            new Vector3(targetDirection.x, transform.position.y, targetDirection.z),
            Vector3.up
        );

        nextLaunchTime = Time.time + cooldown;
    }
}