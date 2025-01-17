using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    public bool isEngineBlockPlaced = false;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PartPlaced(string partName)
    {
        if (partName == "EngineBlock")
        {
            isEngineBlockPlaced = true;
            Debug.Log("Blok silnika zamontowany!");
        }
        else if (partName == "CylinderHead")
        {
            if (isEngineBlockPlaced)
            {
                Debug.Log("G�owica silnika zamontowana!");
            }
            else
            {
                Debug.LogError("Nie mo�na zamontowa� g�owicy przed blokiem silnika!");
            }
        }
    }
}
