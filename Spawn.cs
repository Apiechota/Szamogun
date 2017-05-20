using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject mob;
	private GameObject ten;
	public Transform[] punkt1,punkt2,punkt3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {

			ten=(GameObject) GameObject.Instantiate (mob, transform.position, new Quaternion (0, 0, 0, 0));
			ten.GetComponent<AIpath>().punkty=punkt1;
		//	GetComponent<mobs>().AddMob(ten.transform);
			//SendMessage("AddMob",ten.transform);
		}
	}
}
