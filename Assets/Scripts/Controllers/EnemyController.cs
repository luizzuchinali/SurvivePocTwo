using UnityEngine;

[RequireComponent(typeof(EnemyCharacter))]
public class EnemyController : MonoBehaviour
{
    private EnemyCharacter _character;
    private PlayerController _playerController;
    private Transform _characterTransform;

    private void Awake()
    {
        _character = GetComponent<EnemyCharacter>();
        _characterTransform = _character.transform;
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (_character.Fighter.IsDead())
        {
            SceneEnemies.DestroyEnemy(GetInstanceID());
            return;
        }

        MoveRoutine();
    }

    private void MoveRoutine()
    {
        var playerCharacterPosition = _playerController.GetCharacterPosition();
        var characterPosition = _characterTransform.position;

        _character.Mover.LookAt(new Vector3(playerCharacterPosition.x, characterPosition.y, playerCharacterPosition.z));

        var direction = playerCharacterPosition - characterPosition;
        var distance = direction.magnitude;
        //TODO: get character range to attack if distance < range
        if (distance > 1.5)
        {
            var normalizedDir = direction.normalized;
            _character.Mover.Move(normalizedDir.x, normalizedDir.z);
        }
    }
}