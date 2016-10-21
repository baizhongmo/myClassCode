using UnityEngine;
using System.Collections;

public class OnSkillCD : MonoBehaviour {
	public UISprite skillSp;
	public UILabel timeLabel;
	private bool isCanAttack = true;
	private float currentTime;
	public  float totalTime=5;
	private float hasTime;
	private bool  isDie = false;
	private bool ismp=true;
	public UIProgressBar MP;
	// Use this for initialization
	void Start () {
		currentTime = 0;
		timeLabel.enabled = false;
	
	}

	// Update is called once per frame
	void Update () {
		if (skillSp.fillAmount.Equals (1)) {
			return;
		}
		currentTime += Time.deltaTime;
		hasTime = totalTime-Mathf.FloorToInt (currentTime);
		timeLabel.text = hasTime.ToString ();
		float fill = currentTime / totalTime;
		skillSp.fillAmount = fill;
		if (currentTime >= totalTime) {
			isCanAttack = true;
			currentTime = 0;
			timeLabel.enabled = false;
			this.GetComponent <UIButton> ().enabled = true;
		}
	}
	 public void OnClick1(){
		if (isCanAttack&&MP.value >0.1) {
			skillSp.fillAmount = 0;
			isCanAttack = false;
			timeLabel.enabled = true;
		
			GetComponent<UIButton> ().enabled = false;
		}
	}


}
