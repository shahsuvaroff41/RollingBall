using UnityEngine;

namespace MiniGame.Camera
{
    public class FollowCam : MonoBehaviour
    {
        private Vector3 _offset;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _offset = transform.position - _player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}