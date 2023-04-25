using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacle : MonoBehaviour
{
        [SerializeField]
        private CircleBounds bounds;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Update()
        {
            
            var player = GameObject.FindWithTag("player");
            if (player != null)
            {
                var playerBounds = player.GetComponent<CircleBounds>();
                var collideWithPlayer = bounds.Collides(playerBounds);
                if (collideWithPlayer)
                {
                    SceneManager.LoadScene(1);
                    PlayerPrefs.SetInt("Play.Score", 0);
                    PlayerPrefs.Save();
                    GameObject.Destroy(player);
                }
            }
        }
}
