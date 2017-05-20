using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class AIpath : MonoBehaviour {
	public Transform[] punkty;
	
	public float szybkoscruchu=1;
	public bool czyZapetlac=true;
	private CharacterController kontroler;
	public int Obecnycel;
	public float walkSpeed = 5.0f;
	public bool stop=false;
	private Vector3 kierunek=Vector3.zero;
	public bool z= false,wymija=false;
	public Quaternion targetRotation;

	// Use this for initialization
	void Start () {
	kontroler=GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	if(kontroler!=null)
		{


			if(kontroler.isGrounded)
		{
			
			mov();
		}
	
		}
		
	}
void mov()
{

		if (!stop) {
			if(!wymija)
			{targetRotation = Quaternion.LookRotation (punkty [Obecnycel].transform.position - transform.position);

			float oryginalX = transform.rotation.x;
			float oryginalZ = transform.rotation.z;
			
			Quaternion finalRotation = Quaternion.Slerp (transform.rotation, targetRotation, 5.0f * Time.deltaTime);
			transform.rotation = finalRotation;
			}
			float distance = Vector3.Distance (transform.position, punkty [Obecnycel].transform.position);
			if (distance > 1.0) {
				transform.Translate (Vector3.forward * walkSpeed * Time.deltaTime);
				GetComponent<Animation> ().Play ("walk");
			} else
			{
				if(Obecnycel<punkty.Length)
				Obecnycel++;
				else
					stop=true;
			}
		}
		else {
			//float dd=Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);

		}



}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag=="Enemy")
		if (!z) {
			z=true;
			StartCoroutine(czekam ());
			
		}
		
		
	}

	
	IEnumerator czekam()
	{
		wymija = true;
		//targetRotation = new Quaternion (0,Random.Range(0,360),0,0);
		transform.Rotate ( new Vector3 (0, Random.Range (0, 360), 0));
		yield return new WaitForSeconds(2);
		wymija = false;
		z = false;
	}





}

