using System.Globalization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Fighter))]
public class EnemyController : MonoBehaviour
{
    public TextMeshPro damageTextPrefab;
    private PlayerController _playerController;

    private Mover _mover;
    private Fighter _fighter;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _fighter = GetComponent<Fighter>();
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (_fighter.IsDead())
        {
            SceneEnemies.DestroyEnemy(GetInstanceID());
            return;
        }

        MoveRoutine();
    }

    private void MoveRoutine()
    {
        var playerCharacterPosition = _playerController.transform.position;
        var characterPosition = transform.position;

        _mover.LookAt(new Vector3(playerCharacterPosition.x, characterPosition.y, playerCharacterPosition.z));

        var direction = playerCharacterPosition - characterPosition;
        var distance = direction.magnitude;
        //TODO: get character range to attack if distance < range
        if (distance > 1.5)
        {
            var normalizedDir = direction.normalized;
            _mover.Move(normalizedDir.x, normalizedDir.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(Tags.PlayerSkill)) return;

        var skill = other.GetComponent<BaseSkill>();
        _fighter.TakeDamage(skill.damage);
        var position = transform.position;
        var instance = Instantiate(damageTextPrefab, new Vector3(position.x, position.y + 1.5f, position.z),
            Quaternion.identity);
        instance.SetText(skill.damage.ToString(CultureInfo.InvariantCulture));
        Destroy(instance.gameObject, 0.4f);
    }
}