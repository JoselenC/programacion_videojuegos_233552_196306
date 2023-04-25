using System;
using System.Collections;
using System.Collections.Generic;
using logic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSc : MonoBehaviour
{
    [SerializeField]
    private CircleBounds bounds;
    [SerializeField]
    private SquadBounds sqBounds;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    
    private void Update()
    {
        var player = GameObject.FindWithTag("player");
        if (player != null)
        {
            var playerBounds = player.GetComponent<CircleBounds>();
            if (bounds != null && playerBounds!=null)
            {
                var collideWithPlayer = bounds.Collides(playerBounds);
                if (collideWithPlayer)
                {
                    var level = PlayerPrefs.GetInt("Play.Level", 2);
                    if (level >= 5)
                    {
                        level = 2;
                    }

                    level += 1;
                    PlayerPrefs.SetInt("Play.Level", level);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(1);
                }
                
            }
            
            if (sqBounds != null && playerBounds!=null)
            {
                var collideWithPlayer = sqBounds.Collides(playerBounds);
                if (collideWithPlayer)
                {
                    var level = PlayerPrefs.GetInt("Play.Level", 2);
                    if (level >= 20)
                    {
                        level = 2;
                    }

                    level += 1;
                    PlayerPrefs.SetInt("Play.Level", level);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(1);
                }
            }
        }
        
        
    }
    
}
