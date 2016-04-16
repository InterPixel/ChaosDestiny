using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {

	float healthPoints;		//hit points
	float manaPoints;		//mana points
	float actionPoints;		//action / ability point. Certain (melee) skill use this

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
	bool displayed = false;

	GameObject hpBarObject;
	GameObject mpBarObject;
	GameObject apBarObject;
	GameObject expBarObject;
	Slider HPBar;
	Slider MPBar;
	Slider APBar;
	Slider EXPBar;

	//inflict damage to player
	public void TakeDamage(int damage){
		healthPoints = healthPoints - damage;
	}

	public void Stun(int duration){
		StartCoroutine(StartStun(duration));
	}

	// Use this for initialization
	void Start () {
		strength = PlayerPrefs.GetInt("strength");
		defence = PlayerPrefs.GetInt("defence");
		stamina = PlayerPrefs.GetInt("stamina");
		intelligence = PlayerPrefs.GetInt("intelligence");
		agility = PlayerPrefs.GetInt("agility");
		vitality = PlayerPrefs.GetInt("vitality");

		hpBarObject = GameObject.Find("HPBar");
		mpBarObject = GameObject.Find("MPBar");
		apBarObject = GameObject.Find("APBar");
		expBarObject = GameObject.Find("EXPBar");

		HPBar = hpBarObject.GetComponent<Slider>();
		MPBar = mpBarObject.GetComponent<Slider>();
		APBar = apBarObject.GetComponent<Slider>();
		EXPBar = expBarObject.GetComponent<Slider>();

		infoText = GameObject.Find("Info");

		maxHealthPoints = 1000f;
		maxManaPoints = 100f;
		maxActionPoints = 50f;

		healthPoints = 100f;
		manaPoints = maxManaPoints;
		actionPoints = maxActionPoints;
		
		hpRegenRate = 1;
		mpRegenRate = 1;
		apRegenRate = 1;

		StartCoroutine(HPRegen());
		StartCoroutine(MPRegen());
		StartCoroutine(APRegen());
	}

	
	
	// Update is called once per frame
	void Update () {
		if(healthPoints <= 0){
			WarningText("You're dead");
			healthPoints = 0f;
		}else if(HPBar.value < 0.2f){
			WarningText("Low HP");
		}

		if(manaPoints <= 0){
			WarningText("You're out of mana");
			manaPoints = 0f;
		}else if(MPBar.value < 0.2f){
			WarningText("Low MP");
		}

		if (actionPoints <= 0){
			WarningText("You're out of AP");
			actionPoints = 0f;
		}else if(APBar.value < 0.2f){
			WarningText("Low AP");
		}

		//show values to GUI bar
		HPBar.value = healthPoints / maxHealthPoints;
		MPBar.value = manaPoints / maxManaPoints;
		APBar.value = actionPoints / maxActionPoints;
		EXPBar.value = exp / maxExp; 
	}

	void FixedUpdate(){
		
	}



//All regenerative coroutines
//regen happens every 0.1 second
	IEnumerator HPRegen(){

		while(true){
			if(healthPoints < maxHealthPoints){
				healthPoints = healthPoints + hpRegenRate;
			}

			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator MPRegen(){

		while (true){
			if(manaPoints < maxManaPoints){
				manaPoints = manaPoints + mpRegenRate;
			}

			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator APRegen(){

		while (true){
			if(actionPoints < maxActionPoints){
				actionPoints = actionPoints + apRegenRate;
			}

			yield return new WaitForSeconds(0.1f);
		}
	}


//used to display warning text on screen
//just pass in the text to show
	public void WarningText(string x){
		if (!displayed){
			StartCoroutine(DisplayWarningText(x));
		}
	}

	IEnumerator DisplayWarningText(string x){
		infoText.GetComponent<Text>().text = x;
		displayed = true;
		yield return new WaitForSeconds(1);
		infoText.GetComponent<Text>().text = "";
		displayed = false;
	}

	//Coroutine for stun effect
	IEnumerator StartStun(int x){
		GetComponent<NynaJoystickControl>().enabled = false;
		yield return new WaitForSeconds(x);
		GetComponent<NynaJoystickControl>().enabled = true;
	}
}