using UnityEngine;
using System.Collections;

public class mobs : MonoBehaviour {

	public GameObject[] moby;
	public Transform[] wrog;
	public int nr=0;


	// Use this for initialization
	void Start () {
		moby = GameObject.FindGameObjectsWithTag ("Enemy");
		nr = moby.Length;
		wrog=new Transform[nr];
		for(int i=0;i<nr;i++)
			wrog[i]=moby[i].transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void DelMob(Transform a)
	{
		Transform[] b=new Transform[nr-1];
		int r = 0;
		for (int i=0; i<nr; i++)
			if (wrog [i] != a.transform) {	//Debug.Log ("Del mob");
			b[r]=wrog[i];
			r++;

			}
		//else
		//	GetComponent<minimap> ().odejmob (i);
		wrog = b;
	
		nr--;

	}
	public void AddMob(Transform a)
	{
		Transform[] b=new Transform[nr+1];

		for (int i=0; i<nr; i++)
			b[i]=wrog[i];
			
		b[nr]= a;
		wrog = b;
	//	GetComponent<minimap> ().dodmob ();
		nr++;
	}


}
