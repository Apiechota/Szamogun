using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour {
	private bool a;
	public GameObject g1;
	public int loadProgress=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0||Input.GetAxis ("Vertical") != 0)
			zastaw ();
	}
	public void ustaw (){
		
		a = true;
		StartCoroutine (loadDig ());
	}
	public void zastaw()
	{
		a = false;
	}

	public	IEnumerator loadDig () {
		
	//	progressBar.SetActive(true);
		 loadProgress=0;
		g1.GetComponent<RectTransform> ().localScale = new Vector3 ((float)loadProgress / 100.0f, 1, 1);
		while(loadProgress<99&&a){
			yield return new WaitForSeconds(0.1f);
			loadProgress += 2;
			g1.GetComponent<RectTransform> ().localScale = new Vector3 ((float)loadProgress / 100.0f, 1, 1);

		}
		yield return null;
	}

}
