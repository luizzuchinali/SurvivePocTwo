using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public BaseSkill baseSkillEffect;

    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void Attack(Vector3 origin, Vector3 targetDirection)
    {
        var instance = Instantiate(baseSkillEffect, transform.position, Quaternion.identity);
        instance.Launch(origin, targetDirection);
        Destroy(instance, baseSkillEffect.duration);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle death here, e.g. play animation, remove from game, etc.
        Debug.Log($"{gameObject.name} has died.");
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}