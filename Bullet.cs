using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health  != null)
		{
			health.takeHit(10,0);
		}

		Destroy(gameObject);
	}
	/*void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime*2);
	}*/
}