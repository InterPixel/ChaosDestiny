using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInNPC : MonoBehaviour {

	float maxHealthPoints;
	float maxManaPoints;
	float maxActionPoints;

	int hpRegenRate;
	int mpRegenRate;
	int apRegenRate;

	float exp;
	float maxExp;

	int strength;			//gk bisa didorong enemy
	int defence;			//decrease damage taken
	int stamina;			//endurance to poison etc. Affect hp regen.
	int intelligence;		//faster magic cooldown / casting.
	int agility;			//move faster
	int vitality;			//max health

	int level;

	GameObject infoText;
	GameObject shop;
	public GameObject Inventory;
	public GameObject PotShop;
	public GameObject Sword;
	public GameObject Staff;
	public GameObject Bow;
	bool displayed = false;

	int npc = 0;


	// Use this for initialization
	void Start () {
		strength = PlayerPrefs.GetInt("strength");
		defence = PlayerPrefs.GetInt("defence");
		stamina = PlayerPrefs.GetInt("stamina");
		intelligence = PlayerPrefs.GetInt("intelligence");
		agility = PlayerPrefs.GetInt("agility");
		vitality = PlayerPrefs.GetInt("vitality");

		infoText = GameObject.Find("Info");
		shop = GameObject.Find("Shop");
		shop.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){

		shop.SetActive(true);

		if(coll.gameObject.name == "BlackSmith"){
			npc = 1;
			WarningText("Speak to the blacksmith");
		}else if(coll.gameObject.name == "Bowyer"){
			npc = 2;
			WarningText("Speak to the bowyer");
		}else if(coll.gameObject.name == "Magician"){
			npc = 3;
			WarningText("Speak to the magician");
		}else if(coll.gameObject.name == "Potion Merchant"){
			npc = 4;
			WarningText("Speak to the potion merchant");
		}else if(coll.gameObject.name == "Special Merchant"){
			npc = 5;
			WarningText("Speak to the special merchant");
		}else if(coll.gameObject.name == "Banker"){
			npc = 6;
			WarningText("Speak to the banker");
		}else if (coll.gameObject.name == "Andrius"){
			npc = 7;
			WarningText("Speak to Andrius");
		}
	}


	void OnTriggerExit2D(){
		WarningText("");
		shop.SetActive(false);
	}

	//used to display warning text on screen
	//just pass in the text to show
	void WarningText(string x){
		infoText.GetComponent<Text>().text = x;
		
	}

	public void Interact(){

		switch(npc){
			case 1:
				Sword.SetActive(true);
				break;
			case 2:
				Bow.SetActive(true);
				break;
			case 3:
				Staff.SetActive(true);
				break;
			case 4:
				PotShop.SetActive(true);
				break;
			case 5:
				break;
			case 6:
				Inventory.SetActive(true);
				break;
			case 7:
				break;
		}
	}
}
