using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : MonoBehaviour {
	public GameObject bulletPrefab,cam;
	public Transform bulletSpawn;
	private bool a,b,c,d;
	// Use this for initialization
	void Start () {
		c = true;
		d = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)&&a) {
			if (b) {
				if (c) {
					CmdFire ();
					StartCoroutine (pal());
				}
			} else {
				if (d) {

				}
			}
		}

	}
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		print ("Bullet");
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			cam.transform.rotation);

		// Add velocity to the bullet
		//bullet.transform.rotation=new Quaternion(cam.transform.rotation.x,gameObject.transform.rotation.y,gameObject.transform.rotation.z,0);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward*6;

		// Spawn the bullet on the Clients
	

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
	public void ustaw (bool e){
		print ("Ustaw");
		a = true;
		b = e;
	}
	public void zastaw()
	{
		a = false;
	}
	IEnumerator pal()
	{
		c = false;
		yield return new WaitForSeconds(2);

		c = true;
	}
	IEnumerator pal2()
	{
		d = false;
		yield return new WaitForSeconds(0.5f);

		d = true;
	}
}
