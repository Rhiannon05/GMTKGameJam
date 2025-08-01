using UnityEngine;

[System.Serializable]
public class CellCode : MonoBehaviour
{
    public string cellName;
    public string cellDescription;
    public int healthImpact; // +value for good cells, -value for bad cells
    public bool isAccepted;  // Set true when player chooses to accept

    public enum CellType { Good, Bad }
    public CellType cellType;

    public void AcceptCell(HealthAndVitality healthSystem)
    {
        isAccepted = true;

        // Apply the effect only if accepted
        ApplyEffect(healthSystem);
    }

    public void RejectCell()
    {
        isAccepted = false;
        // Do nothing, as rejecting has no effect
    }

    private void ApplyEffect(HealthAndVitality healthSystem)
    {
        // Only apply health change if accepted
        if (!isAccepted) return;

        if (cellType == CellType.Good)
        {
            healthSystem.ModifyHealth(Mathf.Abs(healthImpact)); // Heal
        }
        else if (cellType == CellType.Bad)
        {
            healthSystem.ModifyHealth(-Mathf.Abs(healthImpact)); // Damage
        }
    }
}