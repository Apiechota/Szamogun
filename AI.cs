using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public GameObject bulletPrefab,bulletSpawn,ocel,cel;
	public bool blokada=false;
	public bool blokada2=false,blok=false;
	public GameObject sys;
	
	// Rotation Speed
	public float rotationSpeed = 35;


	RaycastHit hit,hit2,hit3;
	public float closestDistanceSqr;

	IEnumerator czekam()
	{

		blokada2 = true;
		yield return new WaitForSeconds(1);
		if (!blokada)
			CmdFire ();
		blokada2 = false;
		blokada = true;
	}



	void Start()
	{
/*
		mobs = GameObject.FindGameObjectsWithTag ("Enemy");
		nr = mobs.Length;
		wrog=new Transform[nr];
		for(int i=0;i<nr;i++)
			wrog[i]=mobs[i].transform;

*/
		blokada = true;
		blokada2 = false;
		sys = GameObject.Find ("System");
	}
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		print ("Bullet");
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.transform.position,
			ocel.transform.rotation);

		// Add velocity to the bullet
		//bullet.transform.rotation=new Quaternion(cam.transform.rotation.x,gameObject.transform.rotation.y,gameObject.transform.rotation.z,0);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward*16;

		// Spawn the bullet on the Clients


		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
	void Update() {

		if (!blokada2 ) {

		try
			{
			transform.LookAt(GetClosestEnemy(sys.GetComponent<mobs>().wrog).position+new Vector3(0,1,0));
			}
			catch
			{

			}

				StartCoroutine (czekam ());

			}

		}



	void Blokuj(bool a)
	{
		blok = a;
	}

	Transform GetClosestEnemy (Transform[] enemies)
	{
		
		Transform bestTarget = null,midTarget=null,lastTarget=null;
		 closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(Transform potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				lastTarget = midTarget;
				midTarget = bestTarget;
				bestTarget = potentialTarget;

			}
		}
		cel.transform.LookAt (bestTarget.transform.position-new Vector3(0,-1,0));
		Ray ray = new Ray(ocel.transform.position,bestTarget.transform.position-ocel.transform.position);

		if (Physics.Raycast (ray, out hit)) {

			if (hit.transform.name.Equals (bestTarget.name)) {
				blokada = false;
				return bestTarget;
			}
				//umiesc obiekt
			else {
				cel.transform.LookAt (midTarget.transform.position-new Vector3(0,-1,0));
				Ray ray2 = new Ray(ocel.transform.position,midTarget.transform.position-ocel.transform.position);

				if (Physics.Raycast (ray2, out hit2)) {

					if (hit2.transform.name.Equals (midTarget.name)) {
						blokada = false;
						return midTarget;
			
					}
				else
					{	cel.transform.LookAt (lastTarget.transform.position-new Vector3(0,-0.96f,0));
					Ray ray3 = new Ray(ocel.transform.position,lastTarget.transform.position-ocel.transform.position);

					if (Physics.Raycast (ray3, out hit3)) {

							if (hit3.transform.name.Equals (lastTarget.name)) {
								blokada = false;
								return lastTarget;
							}
							else {
								blokada = true;
								return lastTarget;
							}
					}
					}
		}

		}
		}
		return bestTarget;
	}






}
