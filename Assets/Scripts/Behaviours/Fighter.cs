using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public BaseSkill baseSkillEffectPrefab;

    private float _nextAttackTime;

    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void Attack(Vector3 targetDirection)
    {
        if (IsDead()) return;
        if (Time.time <= _nextAttackTime) return;

        var position = transform.position;

        var instance = Instantiate(baseSkillEffectPrefab, position, Quaternion.identity);

        var angle = Vector3.SignedAngle(instance.transform.forward, targetDirection, Vector3.up);
        instance.transform.Rotate(0, angle, 0);

        _nextAttackTime = Time.time + baseSkillEffectPrefab.cooldown;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
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