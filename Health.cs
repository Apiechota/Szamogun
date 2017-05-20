using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public float zycie=100,maxzycie;
	public GameObject g1,g2,sys;
	public int[] odpornosc;
	// Use this for initialization
	void Start () {
		sys = GameObject.Find ("System");
		maxzycie = zycie;
	}
	
	// Update is called once per frame
	void Update () {
		g1.GetComponent<RectTransform> ().localScale = new Vector3 ((float)zycie / (float)maxzycie, 1, 1);
		
		g2.transform.LookAt(GameObject.FindWithTag("Player").transform.position);
		if (zycie <= 0) {
			sys.SendMessage("DelMob",transform);
			//sys.GetComponent<StartSpawns>().zab++;
			//sys.GetComponent<Score>().wynikododaj(1);
			Destroy (this.gameObject);

		}
	}
	public void takeHit(float hit,int source)
	{
		bool byl = false;
		for (int i=0; i<odpornosc.Length; i++)
			if (odpornosc [i] == source) {
				zycie -= 0.1f * hit;
			byl=true;
		}
		if(!byl)
		zycie -= hit;

	}




}
