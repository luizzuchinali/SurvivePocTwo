using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject characterGameObject;
    public Transform characterSpawnPosition;

    private EnemyCharacter _character;
    private PlayerController _playerController;
    private Transform _characterTransform;

    private void Awake()
    {
        var instance = Instantiate(
            characterGameObject,
            characterSpawnPosition.position,
            Quaternion.identity,
            transform
        );

        _character = instance.GetComponent<EnemyCharacter>();
        _characterTransform = _character.transform;
    }

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        var playerCharacterPosition = _playerController.GetCharacterPosition();

        _character.Mover.LookAt(new Vector3(playerCharacterPosition.x, 0, playerCharacterPosition.z));

        var direction = playerCharacterPosition - _characterTransform.position;
        var distance = direction.magnitude;
        Debug.Log(direction);
        //TODO: get character range to attack if distance < range
        if (distance > 0.4)
        {
            var normalizedDir = direction.normalized;
            Debug.Log(normalizedDir);
            _character.Mover.Move(normalizedDir.x, normalizedDir.z);
        }
    }
}