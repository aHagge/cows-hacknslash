﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

	private NavMeshAgent mNavMeshAgent;
	private bool mRunning;
	private int layerMask = ~(1 << 10);
	
	[Header("Misc")]
	public GameObject cursorClick;
	void Start () {
		mNavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		if(Input.GetMouseButton(0))
		{
			if(Physics.Raycast(ray, out hit, 100, layerMask))
			{
				mNavMeshAgent.destination = hit.point;
				
			}
		}

		if(Input.GetMouseButtonDown(0))
		{	
			if(Physics.Raycast(ray, out hit, 100, layerMask))
			{
				Vector3 spawnPoint = hit.point + new Vector3(0,0.1f,0);

				Instantiate(cursorClick, spawnPoint ,Quaternion.identity);
			}
		}

		//When animations get added
		if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
		{
			mRunning = false;
		} else {
			mRunning = true;
		}
	}
}
