using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIeq : MonoBehaviour {
	public GameObject frame,player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			frame.transform.position = new Vector3 (-30, 33, 1);
			zastaw ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			zastaw ();
			frame.transform.position = new Vector3 (30, 33, 1);

		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			zastaw ();
			frame.transform.position = new Vector3 (90, 33, 1);
			player.GetComponent<Atak> ().ustaw (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			zastaw ();
			frame.transform.position = new Vector3 (150, 33, 1);
			player.GetComponent<Atak> ().ustaw (false);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			zastaw ();
			frame.transform.position = new Vector3 (210, 33, 1);
			player.GetComponent<Dig> ().ustaw ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			zastaw ();
			frame.transform.position = new Vector3 (270, 33, 1);

		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			zastaw ();
			frame.transform.position = new Vector3 (330, 33, 1);

		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			zastaw ();
			frame.transform.position = new Vector3 (390, 33, 1);

		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			zastaw ();
			frame.transform.position = new Vector3 (450, 33, 1);

		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			
			frame.transform.position = new Vector3 (510, 33, 1);

		}
	}

	private void zastaw()
	{
		player.GetComponent<Atak> ().zastaw ();
		player.GetComponent<Dig> ().zastaw ();
	}
}
