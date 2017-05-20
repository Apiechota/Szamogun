using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class StartSpawns : MonoBehaviour {

	public bool blokada,end=false;
	private GameObject ten;
	public GameObject[] mob;
	public int oi = 0,wypr=0;
	public int zab=0,dowyb=10;
	public GameObject obj;


	public List<FalaStructure> fala1;

	public Transform[] pola;
	public int nrpola;
	public int lvl=0,nrtypu=0,maxlvl=2;
	IEnumerator czekam()
	{
		yield return new WaitForSeconds(5);
		nrpola = Random.Range (0,3);
		ten=(GameObject) GameObject.Instantiate (mob[fala1[lvl].fal.mobfal[nrtypu].typ], pola[nrpola].position, new Quaternion (0, 0, 0, 0));
		nrpola = Random.Range (0,3);
		switch (nrpola) {
		case 0:
			ten.GetComponent<AIpath> ().punkty = GetComponent<Spawn> ().punkt1;
			break;
		case 1:
			ten.GetComponent<AIpath> ().punkty = GetComponent<Spawn> ().punkt2;
			break;
		case 2:
			ten.GetComponent<AIpath> ().punkty = GetComponent<Spawn> ().punkt3;
			break;
		}
	//	GetComponent<mobs>().AddMob(ten.transform);
		oi++;
		wypr++;
		zaczynamspawn ();
	}
	IEnumerator czekam2()
	{
		yield return new WaitForSeconds(5);
	//	GetComponent<Score> ().end ();
	//	PlayerPrefs.SetInt ("lvl",GetComponent<Score>().lvl+1);
	//	StartCoroutine (GetComponent<Menu> ().DisplayLoadingScreen (1));
	}

	// Use this for initialization
	void Start () {
		blokada = true;
		end = true;
		oi = 0;
		lvl = 0;
		nrtypu=0;
		maxlvl=2;

	}
	
	// Update is called once per frame
	void Update () {
	//	wyb.GetComponent<Text> ().text = zab.ToString ();

	if (zab == dowyb && blokada) {
			blokada=false;
			if(lvl<maxlvl)
			{	
			
				spawnstart();
			
			}
			else
			{
			obj.SetActive (true);
			StartCoroutine( czekam2());
			}
		}
	}

	public void spawnstart()
	{
		dowyb = 0;
		for (int i=0; i<fala1[lvl].fal.iletypow; i++)
			dowyb += fala1 [lvl].fal.mobfal[i].ilo;

		zab = 0;
		nrtypu = 0;
		oi = 0;
		wypr = 0;
		blokada = true;
		zaczynamspawn ();
	}

	public void zaczynamspawn()
	{

		if (wypr == dowyb) {
			lvl++;
		} else {


			if (oi == fala1[lvl].fal.mobfal[nrtypu].ilo) {
				nrtypu++;
				oi=0;
				StartCoroutine (czekam ());

			} else {
				StartCoroutine (czekam ());
			}

		}

	}
}
