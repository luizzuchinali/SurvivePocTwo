using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown = 1f;
    public float duration = 1f;

    public virtual void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}