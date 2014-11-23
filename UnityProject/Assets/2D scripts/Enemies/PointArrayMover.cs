using UnityEngine;
using System.Collections;

/// <summary>
/// Judėjimas iš taško į tašką tam tikru greičiu
/// 
/// Roman Osipov
/// </summary>
public class PointArrayMover : MonoBehaviour {

	public Vector2[] destinations;                  // Taškai per kūriuos keliaus
    public Vector2 startingPosition;                // Pozicija paskutinio update metu, prieš pirmąjį update pradinė pozicija
    public AnimationCurve speed;                    // Greičio ir laiko priklausomybė

    private Vector2 currentDestination;
    private int currentDestinationNumber;

    void Start ()
    {
        transform.position = new Vector3(startingPosition.x, startingPosition.y, 0);
        currentDestinationNumber = 0;
        currentDestination = destinations[currentDestinationNumber];
    }
	
	void Update () 
    {
        // Pajudina link currentDestination
        startingPosition = Vector2.MoveTowards(startingPosition, currentDestination, speed.Evaluate(0.5f));
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
