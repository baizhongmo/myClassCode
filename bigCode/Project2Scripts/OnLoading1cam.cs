using UnityEngine;
using System.Collections;

public class OnLoading1cam : MonoBehaviour {
	public UIProgressBar progress;
	// Use this for initialization
	void Start () {

		StartCoroutine (ChangeScene1 ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private IEnumerator ChangeScene1(){
		int diaplayProgress = 0;
		int toProgress = 0;
		AsyncOperation op = Application.LoadLevelAsync (Application .loadedLevel +1);
		op.allowSceneActivation = false;
		while (op.progress < 0.9f) {
			toProgress = (int)op.progress * 100;
			while (diaplayProgress < toProgress) {
				++diaplayProgress;
				SetLoadingPercentage (diaplayProgress);
				yield return new WaitForEndOfFrame ();
			}
		}
		toProgress = 100;
		while (diaplayProgress < toProgress) {
			++diaplayProgress;
			SetLoadingPercentage (diaplayProgress);
			yield return new WaitForEndOfFrame ();
		}
		op.allowSceneActivation = true;
	}
	void SetLoadingPercentage(float value){
		progress .value  = value / 100;
	}
	
	}


