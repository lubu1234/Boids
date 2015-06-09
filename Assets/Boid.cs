using UnityEngine;
using System.Collections;
using System.Collections.Generic;  // necessary for Lists

public class Boid : MonoBehaviour {
	// static list shared among all boid objects
	static public List<Boid>	boids;

	// not using rigidbocy. moving boids directly
	public Vector3	velocity;
	public Vector3	newVelocity;
	public Vector3	newPosition;

	public List<Boid> 	neighbors;		// nearby boids
	public List<Boid> 	collisionRisks; // boids that are too close
	public Boid			closest;		// single closest boid


	// Use this for initialization
	void Awake () {
		if (boids == null) {
			boids = new List<><Boid>();
		}

		boids.Add (this);

		//Give the boid a random pos and vel
		Vector3 randPos = Random.insideUnitSphere * BoidSpawner.S.spawnRadius;
		randPos.y = 0;

		this.transform.position = randPos;
		velocity = Random.onUnitSphere;
		velocity*= BoidSpawner.S.spawnVelocity;

		//Initialize the two Lists
		neighbors = new List<Boid>();
		collisionRisks = new List<Boid>();

		// make this.transform a child of the Boids GO
		this.transform.parent = GameObject.Find ("Boids").transform;

		Color rnadColor = Color.black;
		while (randColor.r + randColor.g + randColor.b < 1.0f) {
			randColor = new Color(Random.value, Random.value,Random.value);
		}

		Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in rends) {
			r.material.color = randColor;
		}
	} // Awake
	
	// Update is called once per frame
	void Update () {
	


	}
}
