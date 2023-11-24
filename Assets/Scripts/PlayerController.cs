using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public GameObject characterGameObject;
    public Transform characterSpawnPosition;


    public CinemachineVirtualCamera virtualCamera;

    private Character _character;
    private Transform _characterTransform;

    private void Start()
    {
        var instance = Instantiate(characterGameObject, characterSpawnPosition.position, Quaternion.identity);

        _character = instance.GetComponent<Character>();
        _characterTransform = _character.transform;

        virtualCamera.Follow = _characterTransform;
        virtualCamera.LookAt = _characterTransform;
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _character.Mover.Move(horizontal, vertical);
    }
}