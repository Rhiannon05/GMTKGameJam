using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject[] cellPrefabs;
    public Transform spawnPoint;
    private GameObject currentCell;

    // Customizable ranges
    public int minHealthImpact = 5;
    public int maxHealthImpact = 20;

    public bool IsCellActive()
    {
        return currentCell != null;
    }

    public void SpawnRandomCell()
    {
        if (IsCellActive()) return;

        // Spawn random prefab
        int index = Random.Range(0, cellPrefabs.Length);
        currentCell = Instantiate(cellPrefabs[index], spawnPoint.position, Quaternion.identity);

        // Assign random cell values
        CellCode cell = currentCell.GetComponent<CellCode>();
        if (cell != null)
        {
            // Randomly assign type
            cell.cellType = (Random.value > 0.5f) ? CellCode.CellType.Good : CellCode.CellType.Bad;

            // Randomize health impact
            int impact = Random.Range(minHealthImpact, maxHealthImpact + 1);
            cell.healthImpact = impact;

            // Optional: give random name/description
            cell.cellName = cell.cellType == CellCode.CellType.Good ? "Helper Cell" : "Corrupted Cell";
            cell.cellDescription = cell.cellType == CellCode.CellType.Good ? "This cell helps your body." : "This cell harms your system.";
        }
    }

    public void DestroyCurrentCell()
    {
        if (currentCell != null)
        {
            Destroy(currentCell);
            currentCell = null;
        }
    }

    public CellCode GetCurrentCell()
    {
        return currentCell?.GetComponent<CellCode>();
    }
}