using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour // Cada objeto monobehaviour podra ser un game object
{
	
	
	// Variables
	// Movimiento horizontal
	public float velocidadHorizontal = 1.0f;
	public bool estaMuerto = false;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// Movimiento del teclado
		float valorDeMovimiento = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
		
		Vector3 posicion = transform.position;
		
		if (posicion.x < -7.3f)
		{
			posicion.x = -7.3f;
		}
		else if (posicion.x > 7.3f)
		{
			posicion.x = 7.3f;
		}
		
		posicion.x += valorDeMovimiento * velocidadHorizontal * Time.deltaTime;
		
		transform.position = posicion;
	}
}