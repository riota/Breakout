using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{	public Transform jugador;
	
	public Vector2 velocidad;
	private Vector2 velocidadOriginal;
	public bool lanzada = false;

	// Use this for initialization
	void Start()
	{
		velocidadOriginal = velocidad;
		velocidad = Vector2.zero;
	}

	// Update is called once per frame
	void Update()
	{
		if(lanzada == false){
			transform.position = jugador.transform.position + Vector3.up;
			if (Input.GetKeyDown (KeyCode.Space)) {
				lanzada = true;

				velocidad = velocidadOriginal;
			}
			return;
		}
		// Guardamos nuestra posición actual
		Vector3 posicion = transform.position;

		// Movemos nuestra variable temporal 'posicion'
		posicion += (Vector3) velocidad * Time.deltaTime;
		
		transform.position = posicion;
	}
	
	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("BarreraIzquierda"))
		{
			Debug.Log("Colision con barrera Izquierda");
			velocidad.x *= -1;
		}
		else if (other.CompareTag("BarreraDerecha"))
		{
			Debug.Log("Colision con barrera Derecha");
			velocidad.x *= -1;
		}
		else if (other.CompareTag("BarreraArriba"))
		{
			Debug.Log("Colision con barrera Arriba");
			velocidad.y *= -1;
		}
		else if (other.CompareTag("BarreraAbajo"))
		{
			Debug.Log("Colision con barrera Abajo");
			lanzada = false;
			velocidad = Vector2.zero;
			ControladorPrincipal.Instance.PierdeVidas();

		}
		else if (other.CompareTag("Player"))
		{
			Debug.Log("Colision con el jugador");
			velocidad.y *= -1;
		}
		else if (other.CompareTag("Ladrillo"))
		{
			Debug.Log("Colision con ladrillo " + other.gameObject);
			
			ControladorPrincipal.Instance.IncrementarPuntos();
			
			// Jugaremos con estos valores
			velocidad.y *= -1;
			
			// Destruir el objeto del ladrillo
			Destroy(other.gameObject);
		}
	}
}