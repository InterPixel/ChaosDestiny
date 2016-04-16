using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateWeapon : MonoBehaviour {

	public GameObject ok;
	public GameObject reroll;
	public GameObject forge;
	public GameObject plus;
	public GameObject min;
	public GameObject nameInputField;
	public GameObject descInputField;
	public GameObject back;
	public Text nameInput;
	public Text nameDisplay;
	public Text descInput;
	public Text descDisplay;
	public Text tier;
	public Text	attack;
	public Text maxHP;
	public Text maxMP;
	public Text regenHP;
	public Text regenMP;
	public Text strength;
	public Text def;
	public Text stamina;
	public Text intelli;
	public Text agility;
	public Text vitality;
	public Text cost;
	public InputField nameField;
	public InputField descField;

	int tierNum = 1;
	int costNum = 1569;

	int Attack;
	int maxhp;
	int maxmp;
	int regenhp;
	int regenmp;
	int Strength;
	int Defence;
	int Stamina;
	int Intelligence;
	int Agility;
	int Vitality;

	string name;
	string desc;

	int xxx;

	public int tipe;

	void OnEnable(){

		tierNum = 1;

		tier.text = tierNum.ToString();
		cost.text = costNum.ToString();
		ok.SetActive(false);
		reroll.SetActive(false);
		forge.SetActive(true);
		plus.SetActive(true);
		min.SetActive(true);
		nameInputField.SetActive(true);
		descInputField.SetActive(true);
		back.SetActive(true);

		maxHP.text = 		"";
		maxMP.text = 	"";
		regenHP.text = 	"";
		regenMP.text = 	"";
		strength.text = 	"";
		def.text = 	"";
		stamina.text = 	"";
		intelli.text = 	"";
		agility.text = 	"";
		vitality.text = 	"";
		attack.text =	"";
		nameDisplay.text =	"";
		nameInput.text = 	"";
		descInput.text = 	"";
		descDisplay.text = 	"";
		name = "";
		desc = "";
		nameField.text = "";
		descField.text = "";
	}

	public void ChangeTier(int x){
		tierNum = tierNum + x;

		if(tierNum < 1){
			tierNum = 1;
		}else if (tierNum > 20){
			tierNum = 20;
		}
		
		tier.text = tierNum.ToString();

		costNum = tierNum * 1569;

		cost.text = costNum.ToString();
	}

	public void OK(){

		int i = Inventory.FindEmptySlot();

		if(i < 36){
			PlayerPrefs.SetInt("invenSlot" + i, 1);
			
			if (tipe == 0){
				PlayerPrefs.SetInt("itemTypeInvenSlot" + i, 0);
			}else if(tipe == 1){
				PlayerPrefs.SetInt("itemTypeInvenSlot" + i, 1);
			}else if(tipe == 2){
				PlayerPrefs.SetInt("itemTypeInvenSlot" + i, 2);
			}

			PlayerPrefs.SetInt("itemNumberInvenSlot" + i, 1);
			PlayerPrefs.SetString("itemNameInvenSlot" + i, name);

			PlayerPrefs.SetInt(name + "attack", Attack);
			PlayerPrefs.SetInt(name + "def", Defence);
			PlayerPrefs.SetInt(name + "regenMP", regenmp);
			PlayerPrefs.SetInt(name + "regenHP", regenhp);
			PlayerPrefs.SetInt(name + "maxHP", maxhp);
			PlayerPrefs.SetInt(name + "maxMP", maxmp);
			PlayerPrefs.SetInt(name + "strength", Strength);
			PlayerPrefs.SetInt(name + "stamina", Stamina);
			PlayerPrefs.SetInt(name + "intelligence", Intelligence);
			PlayerPrefs.SetInt(name + "agility", Agility);
			PlayerPrefs.SetInt(name + "vitality", Vitality);
			PlayerPrefs.SetString(name + "desc", desc);
		}

		gameObject.SetActive(false);
	}

	public void Forge(){

		name = nameInput.text;
		desc = descInput.text;

		int money = PlayerPrefs.GetInt("ruby");
		bool checker = false;

		for(int i = 1; i < 36; i++){
			if(name == PlayerPrefs.GetString("itemNameInvenSlot" + i)){
				checker = true;
			}

		}

		if(name != "" && name != " " && money > costNum && !checker){

			min.SetActive(false);
			plus.SetActive(false);
			forge.SetActive(false);
			nameInputField.SetActive(false);
			descInputField.SetActive(false);
			back.SetActive(false);

			nameDisplay.text = name;
			descDisplay.text = desc;

			StartCoroutine(InterestingRoll());

			money = money - costNum;
			PlayerPrefs.SetInt("ruby", money);

			xxx = 0;
		}
	}

	public void ReRoll(){
		ok.SetActive(false);
		reroll.SetActive(false);
		xxx = 1;

		StartCoroutine(InterestingRoll());

	}
	
	void Roll(){

		int maxRoll;
		int minRoll;

		maxRoll = tierNum * 10;
		minRoll = maxRoll - 20;

		if (minRoll < 0){
			minRoll = 0;
		}

		maxhp 		= Random.Range(minRoll, maxRoll);	
		maxmp		= Random.Range(minRoll, maxRoll);		
		regenhp		= Random.Range(minRoll, maxRoll);	
		regenmp		= Random.Range(minRoll, maxRoll);	
		Strength	= Random.Range(minRoll, maxRoll);	
		Defence		= Random.Range(minRoll, maxRoll);
		Stamina		= Random.Range(minRoll, maxRoll);
		Intelligence= Random.Range(minRoll, maxRoll);
		Agility		= Random.Range(minRoll, maxRoll);
		Vitality	= Random.Range(minRoll, maxRoll);

		maxHP.text = "+" + maxhp.ToString();	
		maxMP.text = "+" + maxmp.ToString();
		regenHP.text = "+" + regenhp.ToString();
		regenMP.text = "+" + regenmp.ToString();
		strength.text = "+" + Strength.ToString();
		def.text = "+" + Defence.ToString();
		stamina.text = "+" + Stamina.ToString();
		intelli.text = "+" + Intelligence.ToString();
		agility.text = "+" + Agility.ToString();
		vitality.text = "+" + Vitality.ToString();

		Attack = Random.Range(tierNum * 2000 - 2000, tierNum * 2000);
		attack.text = Attack.ToString();
	}

	IEnumerator InterestingRoll(){

		for (int i = 0; i < 25; i++){
			Roll();
			yield return new WaitForSeconds(0.08f);
		}

		if(xxx == 0){
			reroll.SetActive(true);
		}
		ok.SetActive(true);
	}

	public void Tutup(){
		gameObject.SetActive(false);
	}

}
