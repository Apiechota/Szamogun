// Prints the name of the object camera is directly looking at
using UnityEngine;
using System.Collections;

public class LookingOn : MonoBehaviour
{
	public GameObject to,tu;
	private bool st,widmo;
	private string nazwa;
	Camera camera;
	RaycastHit hit;
	void Start()
	{
		camera = GetComponent<Camera>();
		st = false;
		nazwa = "a";
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
			{
				if (st&&widmo) {
					print ("Obiekt ");
					st = false;
					GameObject.Instantiate (tu,to.transform.position,new Quaternion(0,0,0,0));
				hit.transform.tag = "Untagget";
					widmo = false;
					to.SetActive (false);
				}
			}
		
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			st = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)||Input.GetKeyDown (KeyCode.Alpha3)||Input.GetKeyDown (KeyCode.Alpha4)||Input.GetKeyDown (KeyCode.Alpha5)||Input.GetKeyDown (KeyCode.Alpha6)) {
			st = false;
			widmo = false;
		}
		if(st)
		{

			Ray ray = camera.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));

			if (Physics.Raycast (ray, out hit)) {
				if (!nazwa.Equals (hit.transform.name) && hit.transform.tag == "Build") {
					widmo = true;
					nazwa = hit.transform.name;
					to.SetActive (true);
					to.transform.position = hit.transform.position + new Vector3 (0, 1, 0);
					print ("I'm looking at " + hit.transform.name);
					//umiesc obiekt
				}
			} else {
				widmo = false;
				to.SetActive (false);
				print ("I'm looking at nothing!");
			}
		}
		else
			to.SetActive (false);
	}

}
