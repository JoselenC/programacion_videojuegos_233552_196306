using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
   public Text Score;
 
   public Text Level;
    
   // Start is called before the first frame update
   void Start()
   {
      if (Score != null)
      {
         var score = PlayerPrefs.GetInt("Play.Score.Lose", 1);
         Score.text = "Score: " + score;
      }

      if (Level != null)
      {
         var level = PlayerPrefs.GetInt("Play.Level", 2) - 1;
         Level.text = "Level: " + level;
      }
   }
   
   public void PlayGame()
   {
      var level = PlayerPrefs.GetInt("Play.Level", 2);
      SceneManager.LoadScene(level);
   }

   public void QuitGame()
   {
      Debug.Log("QUIT!");
      Application.Quit();
   }
   
}
