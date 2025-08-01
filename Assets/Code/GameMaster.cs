using UnityEngine;
public class GameMaster : MonoBehaviour
{
    public HealthAndVitality healthBar;
    public Randomizer cellRandomizer;
    void Start()
    {
        SpawnNextCell();
    }
    public void OnYesPressed()
    {
        if (!cellRandomizer.IsCellActive()) return;
        CellCode cell = cellRandomizer.GetCurrentCell();
        if (cell != null)
        {
            cell.ApplyEffect(healthBar);
        }
        cellRandomizer.DestroyCurrentCell();
        SpawnNextCell();
    }
    public void OnNoPressed()
    {
        if (!cellRandomizer.IsCellActive()) return;
        cellRandomizer.DestroyCurrentCell();
        SpawnNextCell();
    }
    void SpawnNextCell()
    {
        if (healthBar.IsAlive())
        {
            cellRandomizer.SpawnRandomCell();
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
