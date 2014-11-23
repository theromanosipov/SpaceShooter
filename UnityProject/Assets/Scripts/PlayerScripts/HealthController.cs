using UnityEngine;
using System.Collections;

/// <summary>
/// Kontroliuoja žalos gavimą
/// 
/// ???
/// Roman Osipov
/// </summary>
public class HealthController : GenericPlayerController {
	
    // Material, kuris hitMaterialDuration laikui uždedamas playeriui
    public Material hitMaterial;

    // Originalus laivo material išsaugomas prieš uždedant hitMaterial
    private Material originalMaterial = null;

    // Laikas, kuriam bus uždėtas hitMaterial
	public float hitMaterialDuration;

    // Laikas, iki kurio bus uždėtas hitMaterial
    private float hitMaterialUntil;

	public override void Update(){
		base.Update();
        // Jei originalMaterial != null, tai reiški, kad šiuo metu yra uždėtas hitMaterial
        if (originalMaterial != null && Time.time > hitMaterialUntil) {
            // Grąžina originalMaterial
            gameObject.renderer.material = originalMaterial;
            originalMaterial = null;
        }
	}

    // Uždeda hitMaterial, išsaugo originalMaterial, nuima hitpoints per PlayerInfoContainer
	public void GetDamage(int damage){

        hitMaterialUntil = Time.time + hitMaterialDuration;
        if (originalMaterial == null)
        {
            originalMaterial = gameObject.renderer.material;
            gameObject.renderer.material = hitMaterial;
        }
		
		player.AddHitpoints (-damage);
	}
}
