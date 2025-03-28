using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MiniGame
{
    public class CubeRotate : MonoBehaviour
    {
        public float rotateSpeed, lerpspeed;
        private float currentPose;

        private void Awake()
        {
            currentPose = transform.position.y;
        }
        private void Update()
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
            var posY = Mathf.Lerp(currentPose,currentPose + 0.35f, Mathf.PingPong(Time.time * lerpspeed, 1));
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
    }
}