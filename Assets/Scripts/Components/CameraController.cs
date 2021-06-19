using Characters;
using Controllers;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private MainCharacter _player;
    private Camera _camera;

    [Inject]
    public void Init(MainCharacter player, Camera camera, EventController eventController)
    {
        _player = player;
        _camera = camera;
        eventController.OnUpdate += FollowPlayer;
    }

    private void FollowPlayer()
    {
        _camera.transform.position = _player.transform.position + new Vector3(0, 0, -10);
    }
}