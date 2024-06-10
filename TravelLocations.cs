using UnityEngine;

public class TravelLocations : MonoBehaviour
{
    [SerializeField] private Transform[] _locations;
    [SerializeField] private float _movementSpeed;

    private int _currentLocationIndex = 0;

    private Transform _currentLocation;

    private void Start()
    {
        _currentLocation = _locations[_currentLocationIndex];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentLocation.position, _movementSpeed * Time.deltaTime);

        if (transform.position == _currentLocation.position)
            MoveToNextLocationAndLookAtIt();
    }

    private void MoveToNextLocationAndLookAtIt()
    {
        _currentLocationIndex = (++_currentLocationIndex) % _locations.Length;

        _currentLocation = _locations[_currentLocationIndex];
        transform.forward = _currentLocation.position - transform.position;
    }
}