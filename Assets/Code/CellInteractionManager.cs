using UnityEngine;

public class CellInteractionManager : MonoBehaviour
{
    public Randomizer randomizer;
    public HealthAndVitality healthSystem;

    public void AcceptCell()
    {
        if (!randomizer.IsCellActive()) return;

        CellCode cell = randomizer.GetCurrentCell();
        if (cell != null)
        {
            cell.AcceptCell(healthSystem);
            randomizer.DestroyCurrentCell();
        }
    }

    public void RejectCell()
    {
        if (!randomizer.IsCellActive()) return;

        CellCode cell = randomizer.GetCurrentCell();
        if (cell != null)
        {
            cell.RejectCell();
            randomizer.DestroyCurrentCell();
        }
    }

    public void SpawnNewCell()
    {
        randomizer.SpawnRandomCell();
    }
}