using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class SimpleAgentScript : MonoBehaviour {
	
	public Transform target;
	public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent=GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}
}
