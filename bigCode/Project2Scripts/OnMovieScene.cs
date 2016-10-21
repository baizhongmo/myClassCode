using UnityEngine;
using System.Collections;

public class OnMovieScene : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = this.GetComponent <AudioSource > ();
		movie.Play ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeScene(){
		Application.LoadLevel (1);
	}
}
