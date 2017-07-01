﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
	public float movementDelay = 1;

	private Vector3 currentDirection;
	private Map gameMap;
	// Use this for initialization
	void Start () 
	{
		gameMap = FindObjectOfType<Map>();
		InvokeRepeating("MoveEnemy", 0, movementDelay);
	}

	void MoveEnemy()
	{
		currentDirection = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0);
		//No movement in both axis at once!!
		if (currentDirection.x != 0 && currentDirection.y != 0)
		{
			currentDirection.y = 0;
		}
		//Move if it's free tile.
		if (gameMap != null)
		{
			if (gameMap.canPass(new Vector3(transform.position.x + currentDirection.x, transform.position.y + currentDirection.y, transform.position.z)))
			{
				transform.position += currentDirection;
			}
			else
			{
				MoveEnemy();
			}
		}
	}
}
