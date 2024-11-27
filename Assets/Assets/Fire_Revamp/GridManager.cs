using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public GameObject fireParticleSystem;

    private List<FireCell> gridCells = new List<FireCell>();

    private void Awake()
    {
        Instance = this;
        InitializeGrid();

    }

    public void InitializeGrid()
    {
        foreach (Transform child in transform)
        {
            FireCell cell = child.GetComponent<FireCell>();
            if (cell != null)
            {
                cell.fireParticle = fireParticleSystem;
                gridCells.Add(cell);
            }
        }
    }

    public void SpreadFireToNeighbors(FireCell cells)
    {
        foreach (var neighbor in gridCells)
        {
            if (neighbor == cells || neighbor.isBurning || neighbor.isSpreading) continue;
            float distance = Vector3.Distance(cells.transform.position, neighbor.transform.position);
            if (distance <= cells.burnRadius)
            {
                neighbor.checkedBurn();
            }
        }
    }
}