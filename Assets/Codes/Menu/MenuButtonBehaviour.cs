using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtonBehaviour : MonoBehaviour {

 //This piece of code doesn't contain any default Unity function
 //Please use carefully as all methods are related to how the layout works
 //Renziera

 public GameObject overlay;
 public GameObject exit;
 public GameObject lucky;
 public GameObject feelingLucky;
 public GameObject namefield;
 public GameObject option;
 public GameObject start;
 public GameObject continuee;
 public GameObject help;
 public GameObject about;
 public Text playerNameInText;
 string playerName;
 public int level;

 public void StartGame(){
  //check prefs
  int playerHasPlayed = PlayerPrefs.GetInt("hasPlayed");

  
  if (playerHasPlayed == 0){
  
   PlayerPrefs.SetInt("hasPlayed", 1);

   StartLevel();
  }else{
   overlay.SetActive(true);
   start.SetActive(true);
  }
 } 

 public void StartLevel(){
  SceneManager.LoadScene(level);
  PlayerPrefs.SetInt("ruby", 999999999);
 }

 public void Continue(){
  int playerHasPlayed = PlayerPrefs.GetInt("hasPlayed");

  if (playerHasPlayed == 0){
   overlay.SetActive(true);
   continuee.SetActive(true);
  }else{
   StartLevel();
  }
 }

 public void Option(){
  overlay.SetActive(true);
  option.SetActive(true);
 }

 //for the exit option
 public void Exit(){
  overlay.SetActive(true);
  exit.SetActive(true);
 }

 public void FeelingLucky(){

  //obtain playername in string type
  playerName = playerNameInText.text.ToString();

  //check if player has input any data
  if(playerName == "" || playerName == " "){
    //do nothing if player doesn't input name
  }else{

  //hide first window
  feelingLucky.SetActive(false);
  //show second window
  lucky.SetActive(true);

    int x;
    int y;
    Text Ramalan;
    x = Random.Range(1, 15);
    y = Random.Range(0, 100);
    Ramalan = lucky.GetComponentInChildren<Text>();

    switch (x){
     case 1 :
      Ramalan.text = "Good day awaits you, " + playerName;
      break;
     case 2 :
      Ramalan.text = playerName + ", you must be very lonely. But don't worry, your soulmate will come soon.";
      break;
     case 3 :
      Ramalan.text = "To give happiness is to deserve happiness.";
      break;
     case 4 :
      Ramalan.text = "You should be able to make money and hold on to it.";
      break;
     case 5 :
      Ramalan.text = "Lucky number is " + y;
      break;
     case 6 :
      Ramalan.text = "Nice to see you, " + playerName;
      break;
     case 7 :
      Ramalan.text = "Flat is justice and plot is evil.";
      break;
     case 8 :
      Ramalan.text = "Pride Lust Gluttony Envy Sloth Greed Wrath";
      break;
     case 9 :
      Ramalan.text = "Today is your lucky day indeed, " + playerName;
      break;
     case 10 :
      Ramalan.text = "If you look down the abyss, the abyss will look into you.";
      break;
     case 11 :
      Ramalan.text = "To truly find yourself you should play hide and seek alone.";
      break;
     case 12 :
      Ramalan.text = "Any rough times are now behind you.";
      break;
     case 13 :
      Ramalan.text = "All the effort you're making will ultimately pay off.";
      break;
     case 14 :
      Ramalan.text = "It's your fucking life, live the way you want it. Don't live up to other's expectation.";
      break;
     case 15 : 
      Ramalan.text = "True love will always finds a way.";
      break; 
    }
   }
 }

 public void LuckyDraw(){

  overlay.SetActive(true);
  feelingLucky.SetActive(true);
 }

 //disable all overlay to prevent conflics
 public void DefaultState(){
  overlay.SetActive(false);
  exit.SetActive(false);
  lucky.SetActive(false);
  feelingLucky.SetActive(false);
  option.SetActive(false);
  continuee.SetActive(false);
  start.SetActive(false);
  help.SetActive (false);
  about.SetActive (false);
 }

 //exit application
 public void ExitYes(){
  Application.Quit();
 }
 public void Help(){
  option.SetActive (false);
  help.SetActive (true);
 }
 public void About(){
  option.SetActive (false);
  about.SetActive (true);
 }
}