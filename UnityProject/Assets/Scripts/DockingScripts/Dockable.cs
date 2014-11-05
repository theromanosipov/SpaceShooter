using UnityEngine;
using System.Collections;

/// <summary>
/// Skriptas, kur saugoma alternatyvios laivo formos prefab ( turret/ship )
/// </summary>
public class Dockable : MonoBehaviour {
	
    // Jei šis skriptas prikabintas prie laivo, tai čia saugoma jo turret prefab.
    // Jei prikabintas prie turreto, čia saugoma laivo prefab
	public GameObject otherForm;

}
