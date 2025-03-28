using UnityEngine;

namespace MiniGame.GameNavigator
{
    public class GameNavg : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0;
        }
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                this.enabled = false;
            } 
        }
    }
}
