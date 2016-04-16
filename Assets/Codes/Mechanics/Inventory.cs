using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private enum kondisiSlot {kosong, terisi};

	kondisiSlot[] kondisiSlots = new kondisiSlot[36];	//kosong = 0; terisi = 1;
	int[] tipeItem = new int[36];						//Sword = 0; Bow = 1; Staff = 2; Glyph = 3; HP pot = 4; MP pot = 5;
														//HP pot instant = 6; MP pot instant = 7;  Special = 8; null = 9;
	string[] namaItem = new string[36];
	int[] jumlahItem = new int[36];

	GameObject slot;
	GameObject icon;

	public Sprite sHPpotRegen;
	public Sprite sMPpotRegen;
	public Sprite sHPpotInstant;
	public Sprite sMPpotInstant; 
	public Sprite sGlyph;
	public Sprite sSpecial;
	public Sprite sSword;
	public Sprite sBow;
	public Sprite sStaff;
	public Sprite sNormal;

	GameObject HPPotionDescription;
	GameObject MPPotionDescription;
	GameObject WeaponDescription;
	GameObject GlyphDescription;
	GameObject SpecialDescription;

	int slotSelected;

	void Awake(){

		Item.InitializeItem();

		PlayerPrefs.SetInt("invenSlot1" , 1);
		PlayerPrefs.SetInt("itemTypeInvenSlot1", 5);
		PlayerPrefs.SetInt("itemNumberInvenSlot1", 99);
		PlayerPrefs.SetString("itemNameInvenSlot1", "Lesser Mana Potion");

		PlayerPrefs.SetInt("invenSlot2" , 1);
		PlayerPrefs.SetInt("itemTypeInvenSlot2", 6);
		PlayerPrefs.SetInt("itemNumberInvenSlot2", 23);
		PlayerPrefs.SetString("itemNameInvenSlot2", "Draught of the Magi");

		PlayerPrefs.SetInt("invenSlot3" , 1);
		PlayerPrefs.SetInt("itemTypeInvenSlot3", 8);
		PlayerPrefs.SetInt("itemNumberInvenSlot3", 1);

	}

	void Start(){
		HPPotionDescription = GameObject.Find("HPPotionDescription");
		MPPotionDescription = GameObject.Find("MPPotionDescription");
		WeaponDescription = GameObject.Find("WeaponDescription");
		GlyphDescription = GameObject.Find("GlyphDescription");
		SpecialDescription = GameObject.Find("SpecialDescription");

		HPPotionDescription.SetActive(false);
		MPPotionDescription.SetActive(false);
		WeaponDescription.SetActive(false);
		GlyphDescription.SetActive(false);
		SpecialDescription.SetActive(false);

		ScanInventory();
	}

	void OnEnable(){
		ScanInventory();
	}

	void ScanInventory() {

		

		

		//Kuli semua slot
		for(int i = 1; i <= 35; i++){
			//kosong atau terisi
			kondisiSlots[i] = (kondisiSlot)PlayerPrefs.GetInt("invenSlot" + i);
			
			//Define slot and empty stack number	
			slot = GameObject.Find("Slot (" + i + ")");
			slot.GetComponentInChildren<Text>().text = "";

			//cek tipe item
			tipeItem[i] = PlayerPrefs.GetInt("itemTypeInvenSlot" + i);

			if(kondisiSlots[i] == kondisiSlot.terisi){				
				
				//put sprites
				switch(tipeItem[i]){
					case 0:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sSword;
						break;
					case 1:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sBow;
						break;
					case 2:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sStaff;
						break;
					case 3:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sGlyph;
						break;
					case 4:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sHPpotRegen;
						break;
					case 5:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sMPpotRegen;
						break;
					case 6:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sHPpotInstant;
						break;
					case 7:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sMPpotRegen;
						break;
					case 8:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sSpecial;
						break;
					case 9:
						slot.transform.Find("Icon").GetComponent<Image>().sprite = sNormal;
						break;
				}

				//yang bisa distack
				if(tipeItem[i] > 3 && tipeItem[i] != 9){
					jumlahItem[i] = PlayerPrefs.GetInt("itemNumberInvenSlot" + i);

					slot.GetComponentInChildren<Text>().text = jumlahItem[i].ToString();
				}
					
				namaItem[i] = PlayerPrefs.GetString("itemNameInvenSlot" + i);
					
			}

		}
	}
	
	//function to call then user click on inventory slot
	public void Selected(int slotNumber){

		slotSelected = slotNumber;

		int x = tipeItem[slotNumber];

		if( x == 0 || x == 1 || x == 2){

			HPPotionDescription.SetActive(false);
			MPPotionDescription.SetActive(false);
			WeaponDescription.SetActive(true);
			GlyphDescription.SetActive(false);
			SpecialDescription.SetActive(false);

			string weaponName = PlayerPrefs.GetString("itemNameInvenSlot" + slotNumber);

			WeaponDescription.transform.Find("Name").GetComponent<Text>().text = weaponName;
			WeaponDescription.transform.Find("RegenHP").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "regenHP").ToString();
			WeaponDescription.transform.Find("RegenMP").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "regenMP").ToString();
			WeaponDescription.transform.Find("MaxHP").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "maxHP").ToString();
			WeaponDescription.transform.Find("MaxMP").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "maxMP").ToString();
			WeaponDescription.transform.Find("Strength").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "strength").ToString();
			WeaponDescription.transform.Find("Defence").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "def").ToString();
			WeaponDescription.transform.Find("Stamina").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "stamina").ToString();
			WeaponDescription.transform.Find("Agility").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "agility").ToString();
			WeaponDescription.transform.Find("Vitality").GetComponent<Text>().text = "+" + PlayerPrefs.GetInt(weaponName + "vitality").ToString();
			WeaponDescription.transform.Find("Intelligence").GetComponent<Text>().text ="+" +  PlayerPrefs.GetInt(weaponName + "intelligence").ToString();
			WeaponDescription.transform.Find("Attack").GetComponent<Text>().text = PlayerPrefs.GetInt(weaponName + "attack").ToString();
			WeaponDescription.transform.Find("Description").GetComponent<Text>().text = PlayerPrefs.GetString(weaponName + "desc");


		}else if(x == 3){
			HPPotionDescription.SetActive(false);
			MPPotionDescription.SetActive(false);
			WeaponDescription.SetActive(false);
			GlyphDescription.SetActive(true);
			SpecialDescription.SetActive(false);

			Glyph temp = Item.CallGlyph(namaItem[slotNumber]);

			GlyphDescription.transform.Find("Name").GetComponent<Text>().text = temp.name;
			GlyphDescription.transform.Find("RegenHP").GetComponent<Text>().text = temp.bonusRegenHP.ToString();
			GlyphDescription.transform.Find("RegenMP").GetComponent<Text>().text = temp.bonusRegenMana.ToString();
			GlyphDescription.transform.Find("MaxHP").GetComponent<Text>().text = temp.bonusMaxHP.ToString();
			GlyphDescription.transform.Find("MaxMP").GetComponent<Text>().text = temp.bonusMaxMana.ToString();
			GlyphDescription.transform.Find("Strength").GetComponent<Text>().text = temp.bonusStrength.ToString();
			GlyphDescription.transform.Find("Defence").GetComponent<Text>().text = temp.bonusDef.ToString();
			GlyphDescription.transform.Find("Stamina").GetComponent<Text>().text = temp.bonusStamina.ToString();
			GlyphDescription.transform.Find("Agility").GetComponent<Text>().text = temp.bonusAgility.ToString();
			GlyphDescription.transform.Find("Vitality").GetComponent<Text>().text = temp.bonusVitality.ToString();
			GlyphDescription.transform.Find("Intelligence").GetComponent<Text>().text = temp.bonusIntelligence.ToString();

		}else if(x == 4 || x == 6){

			HPPotionDescription.SetActive(true);
			MPPotionDescription.SetActive(false);
			WeaponDescription.SetActive(false);
			GlyphDescription.SetActive(false);
			SpecialDescription.SetActive(false);

			if(x == 4){

				HPpotRegen temp = Item.CallHPRegen(namaItem[slotNumber]);

				HPPotionDescription.transform.Find("Name").GetComponent<Text>().text = temp.name;
				HPPotionDescription.transform.Find("Dura").GetComponent<Text>().text = temp.duration.ToString();
				HPPotionDescription.transform.Find("Resto").GetComponent<Text>().text = temp.regen.ToString();
			}else if(x == 6){
				HPpotInstant temp = Item.CallHPInstant(namaItem[slotNumber]);

				HPPotionDescription.transform.Find("Name").GetComponent<Text>().text = temp.name;
				HPPotionDescription.transform.Find("Dura").GetComponent<Text>().text = "Instant";
				HPPotionDescription.transform.Find("Resto").GetComponent<Text>().text = temp.regen.ToString();
			}

		

		}else if(x == 5 || x == 7){
			HPPotionDescription.SetActive(false);
			MPPotionDescription.SetActive(true);
			WeaponDescription.SetActive(false);
			GlyphDescription.SetActive(false);
			SpecialDescription.SetActive(false);

			if(x == 5){

				MPpotRegen temp = Item.CallMPRegen(namaItem[slotNumber]);

				MPPotionDescription.transform.Find("Name").GetComponent<Text>().text = temp.name;
				MPPotionDescription.transform.Find("Dura").GetComponent<Text>().text = temp.duration.ToString();
				MPPotionDescription.transform.Find("Resto").GetComponent<Text>().text = temp.regen.ToString();
			}else if (x == 7){

				MPpotInstant temp = Item.CallMPInstant(namaItem[slotNumber]);

				MPPotionDescription.transform.Find("Name").GetComponent<Text>().text = temp.name;
				MPPotionDescription.transform.Find("Dura").GetComponent<Text>().text = "Instant";
				MPPotionDescription.transform.Find("Resto").GetComponent<Text>().text = temp.regen.ToString();
			}

		}else if(x == 8 ){

			HPPotionDescription.SetActive(false);
			MPPotionDescription.SetActive(false);
			WeaponDescription.SetActive(false);
			GlyphDescription.SetActive(false);
			SpecialDescription.SetActive(true);

		}else if(x == 9){
			HPPotionDescription.SetActive(false);
			MPPotionDescription.SetActive(false);
			WeaponDescription.SetActive(false);
			GlyphDescription.SetActive(false);
			SpecialDescription.SetActive(false);
		}
		
	}

	public void DiscardItem(){

		
		PlayerPrefs.SetInt("itemTypeInvenSlot" + slotSelected, 9);
		PlayerPrefs.DeleteKey("itemNumberInvenSlot" + slotSelected);
		PlayerPrefs.DeleteKey("itemNameInvenSlot" + slotSelected);

		
		ScanInventory();
		PlayerPrefs.SetInt("invenSlot" + slotSelected, 0);

		slotSelected = 0;

		HPPotionDescription.SetActive(false);
		MPPotionDescription.SetActive(false);
		WeaponDescription.SetActive(false);
		GlyphDescription.SetActive(false);
		SpecialDescription.SetActive(false);
	}

	public void CloseInven(){
		gameObject.SetActive(false);
	}


	public static int FindEmptySlot(){

		int i = 1;

		while(PlayerPrefs.GetInt("invenSlot" + i) == (int)kondisiSlot.terisi){
			i++;
		}
		return i;
	}

	
}
