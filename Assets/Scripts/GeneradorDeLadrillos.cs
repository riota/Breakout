using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeLadrillos : MonoBehaviour
{
	public GameObject ladrillo;
	
	public Vector2 size;
	public Vector2 offset;

	// Use this for initialization
	void Start()
	{
		StartCoroutine (GenerarLadrillos());
	}

	IEnumerator GenerarLadrillos(){
		for (int x = 0; x < size.x; x++)
		{
			for (int y = 0; y < size.y; y++)
			{
				GameObject ladrilloTemporal = Instantiate(ladrillo, transform.position + new Vector3((offset.x / 2) + x * offset.x, (offset.y / 2) + y * offset.y, 0), Quaternion.identity);

				ladrilloTemporal.transform.SetParent(transform);

				yield return new WaitForSeconds (0.25f);
			}
		}
	}
}