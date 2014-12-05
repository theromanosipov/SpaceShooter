using UnityEngine;
using System.Collections;

/// <summary>
/// Judėjimas iš taško į tašką tam tikru greičiu
/// 
/// Roman Osipov
/// </summary>
public class PointArrayMover : MonoBehaviour {

	public Vector2[] destinations;                  // Taškai per kūriuos keliaus
    public float speed;                             // Greičio ir laiko priklausomybė

    private Vector2 currentDestination;
    private Vector2 currentPosition;
    private int currentDestinationNumber;

    private float startTime;

    private bool isPaused = true;                   // Jei true Update nevyks
	
	void Update () 
    {
        if (isPaused)
            return;

        // Pajudina link currentDestination
        currentPosition = Vector2.MoveTowards(currentPosition, currentDestination, speed);
        transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);

        if (currentDestinationNumber == destinations.Length - 1 && currentPosition == currentDestination)  // Pasiekėme paskutinį destination
        {
            Destroy(gameObject);
        }
        else if (currentPosition == currentDestination)    // Pasiekieme currentDestination
        {
            currentDestinationNumber++;
            currentDestination = destinations[currentDestinationNumber];
        }
	}

    public void SetDestination(Vector2[] points)
    {
        destinations = points;
        transform.position = new Vector3(destinations[0].x, destinations[0].y, 0);
        currentPosition = destinations[0];

        currentDestinationNumber = 1;
        currentDestination = destinations[currentDestinationNumber];

        startTime = Time.time;

        isPaused = false;
    }
}
