using UnityEngine;
using System.Collections;

/// <summary>
/// Judėjimas iš taško į tašką tam tikru greičiu
/// 
/// Roman Osipov
/// </summary>
public class PointArrayMover : MonoBehaviour {

    public Vector2 startingPosition;                // Pozicija paskutinio update metu, prieš pirmąjį update pradinė pozicija
	public Vector2[] destinations;                  // Taškai per kūriuos keliaus
    public float duration;                          // Kiek kartų bus ištempta speed animacija
    public AnimationCurve speed;                    // Greičio ir laiko priklausomybė

    private Vector2 currentDestination;
    private int currentDestinationNumber;

    private float startTime;

    void Start ()
    {
        transform.position = new Vector3(startingPosition.x, startingPosition.y, 0);
        currentDestinationNumber = 0;
        currentDestination = destinations[currentDestinationNumber];

        startTime = Time.time;
    }
	
	void Update () 
    {
        // Pajudina link currentDestination
        startingPosition = Vector2.MoveTowards(startingPosition, currentDestination, speed.Evaluate((Time.time - startTime) / duration));
        transform.position = new Vector3(startingPosition.x, startingPosition.y, 0);

        if (currentDestinationNumber == destinations.Length - 1 && startingPosition == currentDestination)  // Pasiekėme paskutinį destination
        {
            Destroy(gameObject);
        }
        else if (startingPosition == currentDestination)    // Pasiekieme currentDestination
        {
            currentDestinationNumber++;
            currentDestination = destinations[currentDestinationNumber];
        }
	}
}
