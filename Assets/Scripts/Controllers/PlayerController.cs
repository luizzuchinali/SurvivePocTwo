using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Fighter))]
public class PlayerController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private Transform _transform;
    private Mover _mover;
    private Fighter _fighter;

    private void Awake()
    {
        _transform = transform;

        _mover = GetComponent<Mover>();
        _fighter = GetComponent<Fighter>();
    }

    private void Start()
    {
        virtualCamera.Follow = _transform;
        virtualCamera.LookAt = _transform;
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
        _mover.Move(horizontal, vertical);
    }

    private void AttackRoutine()
    {
        var enemyDirection = GetClosestEnemyDirection();
        _fighter.Attack(enemyDirection);
    }

    private Vector3 GetClosestEnemyDirection()
    {
        var closestDistanceSqr = Mathf.Infinity;
        var currentPosition = _transform.position;
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

        Debug.DrawRay(currentPosition, bestTargetDirection.normalized * 10, Color.red, 1f);

        return bestTargetDirection.normalized;
    }
}