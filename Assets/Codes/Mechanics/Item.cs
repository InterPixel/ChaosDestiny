using UnityEngine;
using System.Collections;

public enum weaponTypes {Sword, Bow, Staff };

public struct Weapon{

		public weaponTypes weaponType;
		public string name;
		public string description;
		public int attack;

		public int bonusRegenHP;
		public int bonusRegenMana;
		public int bonusMaxHP;
		public int bonusMaxMana;

		public int bonusStrength;
		public int bonusDef;
		public int bonusStamina;
		public int bonusIntelligence;
		public int bonusAgility;
		public int bonusVitality;


		public int durability;		
	};

	public struct HPpotRegen{

		public string name;
		public int regen;
		public int duration;
	};

	public struct MPpotRegen{

		public string name;
		public int regen;
		public int duration;
	};

	public struct HPpotInstant{

		public string name;
		public int regen;
	};

	public struct MPpotInstant{

		public string name;
		public int regen;
	};

	public struct Glyph{

		public string name;

		public int bonusRegenHP;
		public int bonusRegenMana;
		public int bonusMaxHP;
		public int bonusMaxMana;

		public int bonusStrength;
		public int bonusDef;
		public int bonusStamina;
		public int bonusIntelligence;
		public int bonusAgility;
		public int bonusVitality;
	};

public static class Item {

	public static HPpotRegen ElixirOfBlood;
	public static HPpotRegen ElixirOfVigor;
	public static HPpotRegen ElixirOfRejuvenation;
	public static HPpotRegen ElixirOfDesires;
	public static HPpotRegen ElixirOfRevelation;

	public static MPpotRegen MinorManaPotion;
	public static MPpotRegen LesserManaPotion;
	public static MPpotRegen GreaterManaPotion;
	public static MPpotRegen SuperiorManaPotion;
	public static MPpotRegen MajorManaPotion;

	public static HPpotInstant DraughtOfExcitement;
	public static HPpotInstant DraughtOfShielding;
	public static HPpotInstant DraughtOfTheKing;
	public static HPpotInstant DraughtOfTheSage;
	public static HPpotInstant DraughtOfTheMagi;

	public static MPpotInstant UnstableBrew;
	public static MPpotInstant SpellpowerBrew;
	public static MPpotInstant BrewOfTheReversedTime;
	public static MPpotInstant BrewOfTheOracle;
	public static MPpotInstant BrewOfTheEnigma;

	public static Glyph RadiantBlessing;

	public static void InitializeItem(){

		ElixirOfBlood.name = "Elixir of Blood";
		ElixirOfBlood.regen = 20;
		ElixirOfBlood.duration = 10;

		ElixirOfVigor.name = "Elixir of Vigor";
		ElixirOfVigor.regen = 40;
		ElixirOfVigor.duration = 10;

		ElixirOfRejuvenation.name = "Elixir of Rejuvenation";
		ElixirOfRejuvenation.regen = 5;
		ElixirOfRejuvenation.duration = 200;

		ElixirOfDesires.name = "Elixir of Desires";
		ElixirOfDesires.regen = 80;
		ElixirOfDesires.duration = 20;

		ElixirOfRevelation.name = "Elixir of Revelation";
		ElixirOfRevelation.regen = 160;
		ElixirOfRevelation.duration = 20;

		MinorManaPotion.name = "Minor Mana Potion";
		MinorManaPotion.regen = 20;
		MinorManaPotion.duration = 10;

		LesserManaPotion.name = "Lesser Mana Potion";
		LesserManaPotion.regen = 40;
		LesserManaPotion.duration = 10;

		GreaterManaPotion.name = "Greater Mana Potion";
		GreaterManaPotion.regen = 5;
		GreaterManaPotion.duration = 200;

		SuperiorManaPotion.name = "Superior Mana Potion";
		SuperiorManaPotion.regen = 80;
		SuperiorManaPotion.duration = 20;

		MajorManaPotion.name = "Major Mana Potion";
		MajorManaPotion.regen = 160;
		MajorManaPotion.duration = 20;

		DraughtOfExcitement.name = "Draught of Excitement";
		DraughtOfExcitement.regen = 180;

		DraughtOfShielding.name = "Draught of Shielding";
		DraughtOfShielding.regen = 360;

		DraughtOfTheKing.name = "Draught of the King";
		DraughtOfTheKing.regen = 720;

		DraughtOfTheSage.name = "Draught of the Sage";
		DraughtOfTheSage.regen = 1440;

		DraughtOfTheMagi.name = "Draught of the Magi";
		DraughtOfTheMagi.regen = 2880;


		UnstableBrew.name = "Unstable Brew";
		UnstableBrew.regen = 180;

		SpellpowerBrew.name = "Spellpower Brew";
		SpellpowerBrew.regen = 360;

		BrewOfTheReversedTime.name = "Brew of the Reversed Time";
		BrewOfTheReversedTime.regen = 720;

		BrewOfTheOracle.name = "Brew of the Oracle";
		BrewOfTheOracle.regen = 1440;

		BrewOfTheEnigma.name = "Brew of the Enigma";
		BrewOfTheEnigma.regen = 2880;

		RadiantBlessing.name = "Radiant Blessing";
		RadiantBlessing.bonusRegenHP		= 1;
		RadiantBlessing.bonusRegenMana		= 1;
		RadiantBlessing.bonusMaxHP			= 1;
		RadiantBlessing.bonusMaxMana		= 1;
		RadiantBlessing.bonusStrength		= 1;
		RadiantBlessing.bonusDef			= 1;
		RadiantBlessing.bonusStamina		= 1;
		RadiantBlessing.bonusIntelligence	= 1;
		RadiantBlessing.bonusAgility		= 1;
		RadiantBlessing.bonusVitality		= 1;

		
	}

	public static MPpotRegen CallMPRegen(string x){

		switch(x){
			case "Minor Mana Potion":
				return MinorManaPotion;
				break;
			case "Lesser Mana Potion":
				return LesserManaPotion;
				break;
			case "Greater Mana Potion":
				return GreaterManaPotion;
				break;
			case "Superior Mana Potion":
				return SuperiorManaPotion;
				break;
			case "Major Mana Potion":
				return MajorManaPotion;
				break;
			default:
				return MinorManaPotion;
				break;
		}
	}

	public static MPpotInstant CallMPInstant(string x){

		switch(x){
			case "Unstable Brew":
				return UnstableBrew;
				break;
			case "Spellpower Brew":
				return SpellpowerBrew;
				break;
			case "Brew of the Reversed Time":
				return BrewOfTheReversedTime;
				break;
			case "Brew of the Oracle":
				return BrewOfTheOracle;
				break;
			case "Brew of the Enigma":
				return BrewOfTheEnigma;
				break;
			default:
				return UnstableBrew;
				break;
		}
	}

	public static HPpotRegen CallHPRegen(string x){

		switch(x){
			case "Elixir of Blood":
				return ElixirOfBlood;
				break;
			case "Elixir of Vigor":
				return ElixirOfVigor;
				break;
			case "Elixir of Rejuvenation":
				return ElixirOfRejuvenation;
				break;
			case "Elixir of Desires":
				return ElixirOfDesires;
				break;
			case "Elixir of Revelation":
				return  ElixirOfRevelation;
				break;
			default:
				return ElixirOfBlood;
				break;
		}
	}

	public static HPpotInstant CallHPInstant(string x){

		switch(x){
			case "Draught of Excitement":
				return DraughtOfExcitement;
				break;
			case "Draught of Shielding":
				return DraughtOfShielding;
				break;
			case "Draught of the King":
				return DraughtOfTheKing;
				break;
			case "Draught of the Sage":
				return DraughtOfTheSage;
				break;
			case "Draught of the Magi":
				return DraughtOfTheMagi;
				break;
			default:
				return DraughtOfExcitement;
				break;
		}
	}

	public static Glyph CallGlyph(string x){
		return RadiantBlessing;
	}


}
