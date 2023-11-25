using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject characterGameObject;
    public CinemachineVirtualCamera virtualCamera;

    private PlayerCharacter _character;
    private Transform _characterTransform;

    private void Awake()
    {
        var localTransform = transform;
        var instance = Instantiate(
            characterGameObject,
            localTransform.position,
            Quaternion.identity,
            localTransform
        );

        _character = instance.GetComponent<PlayerCharacter>();
        _characterTransform = _character.transform;
    }

    private void Start()
    {
        virtualCamera.Follow = _characterTransform;
        virtualCamera.LookAt = _characterTransform;
    }

    private void Update()
    {
        MoveRoutine();
        AttackRoutine();
    }

    private void MoveRoutine()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _character.Mover.Move(horizontal, vertical);
    }

    private void AttackRoutine()
    {
        var enemyDirection = GetClosestEnemyDirection();
        _character.Fighter.Attack(GetCharacterPosition(), enemyDirection);
    }

    private Vector3 GetClosestEnemyDirection()
    {
        var closestDistanceSqr = Mathf.Infinity;
        var currentPosition = GetCharacterPosition();
        var bestTargetDirection = Vector3.zero;
        foreach (var potentialTarget in SceneEnemies.GetAllEnemies())
        {
            var directionToTarget = potentialTarget.position - currentPosition;
            var dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTargetDirection = directionToTarget;
            }
        }
        Debug.DrawRay(currentPosition, bestTargetDirection.normalized * 10, Color.red, 5f);

        return bestTargetDirection.normalized;
    }

    public Vector3 GetCharacterPosition() => _characterTransform.position;
}