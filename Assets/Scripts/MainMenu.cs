using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   public Text message;

  public void Play(){
SceneManager.LoadScene("Game");
  }

public void Settings(){
message.text="Not yet available";
}

  public void Quit(){
Application.Quit();
  }
}
