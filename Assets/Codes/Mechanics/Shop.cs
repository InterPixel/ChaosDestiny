using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GameObject Displayer;
	public GameObject ManaDisplay;
	public GameObject HPDisplay;
	public Text money;
	public Text cost;
	public Text stack;

	public Sprite sHPpotRegen;
	public Sprite sMPpotRegen;
	public Sprite sHPpotInstant;
	public Sprite sMPpotInstant;
	public Sprite sTransparent;

	int decider;
	int costNum;
	int totalCost;
	int stackNum;
	int type;

	string myName;

	void OnEnable(){
		Item.InitializeItem();
		ManaDisplay.SetActive(false);
		HPDisplay.SetActive(false);
		money.text = PlayerPrefs.GetInt("ruby").ToString();
		cost.text = "0";
		stack.text = "";
	}

	public void OnSelect(string selectedName){
		myName = selectedName;
		if(decider == 1){
				type = 4;
				HPpotRegen temp = Item.CallHPRegen(selectedName);
			
				HPDisplay.transform.Find("Name").GetComponent<Text>().text = temp.name;
				HPDisplay.transform.Find("Dura").GetComponent<Text>().text = temp.duration.ToString();
				HPDisplay.transform.Find("Resto").GetComponent<Text>().text = temp.regen.ToString();
		}else if (decider == 2){
				type = 5;
				MPpotRegen temp1 = Item.CallMPRegen(selectedName);

				ManaDisplay.transform.Find("Name").GetComponent<Text>().text = temp1.name;
				ManaDisplay.transform.Find("Dura").GetComponent<Text>().text = temp1.duration.ToString();
				ManaDisplay.transform.Find("Resto").GetComponent<Text>().text = temp1.regen.ToString();
		}else if(decider == 3){
				type = 6;
				HPpotRegen temp2 = Item.CallHPRegen(selectedName);

				HPDisplay.transform.Find("Name").GetComponent<Text>().text = temp2.name;
				HPDisplay.transform.Find("Dura").GetComponent<Text>().text = temp2.duration.ToString();
				HPDisplay.transform.Find("Resto").GetComponent<Text>().text = temp2.regen.ToString();
		}else if (decider == 4){
				type = 7;
				MPpotRegen temp3 = Item.CallMPRegen(selectedName);

				ManaDisplay.transform.Find("Name").GetComponent<Text>().text = temp3.name;
				ManaDisplay.transform.Find("Dura").GetComponent<Text>().text = temp3.duration.ToString();
				ManaDisplay.transform.Find("Resto").GetComponent<Text>().text = temp3.regen.ToString();
		}

	}

	public void OnSelected(int x){

		switch(x){
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
				Displayer.transform.Find("Icon").GetComponent<Image>().sprite = sHPpotRegen;

				HPDisplay.SetActive(true);
				ManaDisplay.SetActive(false);
				decider = 1;
				
				break;
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
				Displayer.transform.Find("Icon").GetComponent<Image>().sprite = sMPpotRegen;

				ManaDisplay.SetActive(true);
				HPDisplay.SetActive(false);
				decider = 2;
				break;
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
				Displayer.transform.Find("Icon").GetComponent<Image>().sprite = sHPpotInstant;

				HPDisplay.SetActive(true);
				ManaDisplay.SetActive(false);
				decider = 3;
				break;
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
				Displayer.transform.Find("Icon").GetComponent<Image>().sprite = sMPpotInstant;

				ManaDisplay.SetActive(true);
				HPDisplay.SetActive(false);

				decider = 4;
				break;
		}

		if (x % 10 == 1){
			costNum = 120;
		}else if(x % 10 == 2){
			costNum = 340;
		}else if (x % 10 == 3){
			costNum = 680;
		}else if (x % 10 == 4){
			costNum = 1100;
		}else if (x % 10 == 5){
			costNum = 1620;
		}

		cost.text = costNum.ToString();
		stackNum = 1;
		stack.text = stackNum.ToString();
	}

	public void Stacks(int x){
		stackNum = stackNum + x;

		if(stackNum < 1){
			stackNum = 1;
		}

		totalCost = costNum * stackNum;

		cost.text = totalCost.ToString();
		stack.text = stackNum.ToString();
	}

	public void Buy(){
		int myMoney = PlayerPrefs.GetInt("ruby");

		if(totalCost < myMoney){
			myMoney = myMoney - totalCost;
			PlayerPrefs.SetInt("ruby", myMoney);
			money.text = myMoney.ToString();

			int slot = Inventory.FindEmptySlot();

			if(slot < 36){
				PlayerPrefs.SetInt("invenSlot" + slot, 1);
				PlayerPrefs.SetInt("itemTypeInvenSlot" + slot, type);
				PlayerPrefs.SetInt("itemNumberInvenSlot" + slot, stackNum);
				PlayerPrefs.SetString("itemNameInvenSlot" + slot, myName);
			}

			HPDisplay.SetActive(false);
			ManaDisplay.SetActive(false);
			stack.text = "";
			money.text = PlayerPrefs.GetInt("ruby").ToString();
			cost.text = "0";
			Displayer.transform.Find("Icon").GetComponent<Image>().sprite = sTransparent;
		}
	}
	public void Close(){
		gameObject.SetActive(false);
	}
}
