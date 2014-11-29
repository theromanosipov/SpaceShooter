using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyInfo klasė, kurioje yra saugoma kiek gyvybių turi priešas ir kiek žalos padaro žaidėjui kontakto metu.
/// Taip pat tuti GetDamage metodą.
/// Laivas prisilietęs prie žaidėjo yra sunaikinamas.
/// Turi metodą DestroyShip -> vėliau jame explosion'o inicijavimą reiks įdėt.
/// Viliaus ir Romo
/// </summary>
public class EnemyInfo : MonoBehaviour {
	
	public int HitPoints;		                    // Laivo gyvybės.
	public int ContactDamage;	                    // Kiek žalos daro žaidėjui kontakto metu
	public int killScore = 9;
	public bool isInvincible = false;
	public bool isDestroyableByCollision = true;
	
	private float resetTime;
	private PlayerInfoContainer damager;

    public Color startingColor = new Color(1f, 1f, 1f);

    // Spalvos keitimas
    public Material hitMaterial;                    // Material, kuris hitMaterialDuration laikui uždedamas playeriui
    private Material originalMaterial = null;       // Originalus laivo material išsaugomas prieš uždedant hitMaterial
    public float hitMaterialDuration;               // Laikas, kuriam bus uždėtas hitMaterial
    private float hitMaterialUntil;                 // Laikas, iki kurio bus uždėtas hitMaterial

    void Start()
    {
        gameObject.renderer.material.color = startingColor;
    }

	void Update()
	{
        if (originalMaterial != null && Time.time > hitMaterialUntil)
        {
            // Grąžina originalMaterial
            gameObject.renderer.material = originalMaterial;
            originalMaterial = null;
        }
	}
	
	void GetDamage(int Damage)
	{
        //Debug.Log("gets damage");
		if (isInvincible) {
			gameObject.renderer.material.color = new Color (0.5f, 0.5f, 0.5f);
			return;
		}

        // Uždedamas hitMaterial
        hitMaterialUntil = Time.time + hitMaterialDuration;
        if (originalMaterial == null)
        {
            originalMaterial = gameObject.renderer.material;
            gameObject.renderer.material = hitMaterial;
        }

		HitPoints -= Damage;
		if (HitPoints <= 0) {
			DestroyShip ();
		}
	}

	void SetDamager(PlayerInfoContainer player){
		damager = player;
		}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Player") {
			return;
		}
		//Debug.Log ("Player hit by mover");
		other.gameObject.SendMessage("GetDamage", ContactDamage);
		damager = other.GetComponent<PlayerInfoContainer>();
		if (!isDestroyableByCollision) {
						return;
		}
		DestroyShip ();
	}
	void DestroyShip(){
		if (damager != null)
			damager.AddScore (killScore);
		Destroy (gameObject);
	}
}
