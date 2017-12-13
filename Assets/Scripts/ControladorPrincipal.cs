using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPrincipal : MonoBehaviour
{
	public static ControladorPrincipal Instance;
	public Text puntaje;
	public Text vidasRestantes;
	public int puntos;
	public int vidas = 3;

	public bool juegoTerminado = false;
	public GameObject botondeReinicio;

	// Use this for initialization
	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		botondeReinicio.SetActive (false);
		puntaje.text = "PUNTAJE: 0";
		vidasRestantes.text = "VIDAS: " + vidas.ToString ();;
	}
	
	public void IncrementarPuntos()
	{
		puntos++;
		puntaje.text = "PUNTAJE: " + puntos.ToString ();
		Debug.Log("Puntos incrementados a " + puntos);
	}
	
	public void PierdeVidas()
	{
		vidas--;
		vidasRestantes.text = "VIDAS: " + vidas.ToString();
		if(vidas<= 0){
			juegoTerminado = true;
			botondeReinicio.SetActive(true);
		}
	}

	public void ReiniciarJuego(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Juego");
	}

	public void Salir(){
		Application.Quit ();
	}
}