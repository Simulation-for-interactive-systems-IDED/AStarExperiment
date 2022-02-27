using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField]
    private Pathfinding2D pathFinder;
    private Grid2D pathFinderGrid;

    private void Start()
    {
        pathFinderGrid = pathFinder.GridOwner.GetComponent<Grid2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("<color=yellow>Finding path</color>");
            pathFinder.FindPath(pathFinder.seeker.position, pathFinder.target.position);
            StartCoroutine(TraversePath());
            Debug.Log("<color=green>Path found</color>");
        }
    }

    private IEnumerator TraversePath()
    {
        foreach (var step in pathFinderGrid.path)
        {
            transform.position = step.worldPosition;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
