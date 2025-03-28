using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

namespace MiniGame.Player
{
    public class PlayerInputScript : MonoBehaviour
    {
        private static Rigidbody _rb;
        private float _moveX, _moveZ;
        private AudioSource _audioo;
        public AudioSource loseAudio, winAudio;
        public GameObject parentPickUps;
        public TextMeshProUGUI countTxt;
        [FormerlySerializedAs("gameOverTxt")] public TextMeshProUGUI gameTxt;
        private int _count, _level;
        

        private void Start()
        {
          //  var savedLevel = SaveSystem.LoadLevel();
          //  SceneManager.LoadScene(savedLevel);
            _count = parentPickUps.transform.childCount;
            countTxt.text = "Points Remaining : " + _count;
            _rb = GetComponent<Rigidbody>();
            _audioo = GetComponent<AudioSource>();
            
        }

        private void OnMove(InputValue valueMovement) //called by engine
        {
            var moveVector = valueMovement.Get<Vector2>();
            _moveX = moveVector.x;
            _moveZ = moveVector.y;
        }

        private void FixedUpdate()
        {
            var movement = new Vector3(_moveX, 0, _moveZ);
            _rb.AddForce(movement * 10);
            if (transform.position.y < 0) StartCoroutine(EndGame());
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (!collision.gameObject.CompareTag("Collectible")) return;
            Destroy(collision.gameObject);
            _count--;
            if (_count == 0)
            {
                StartCoroutine(WinGame());
            }

            countTxt.text = "Points Remaining : " + _count;
            _audioo.Play();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine(EndGame());
            }
        }

        private IEnumerator EndGame()
        {
            gameTxt.text = "Game Over!";
            loseAudio.Play();
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        private IEnumerator WinGame()
        {
            gameTxt.text = "You Win!";
            winAudio.Play();
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(2f);
            var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
          // SaveSystem.SaveLevel(nextLevel);
            SceneManager.LoadScene(nextLevel <= 2 ? nextLevel : SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}