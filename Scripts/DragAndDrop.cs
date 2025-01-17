using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset; 
    private Vector3 startPosition; 
    public Camera mainCamera; 
    private bool isDragging = false;

    [SerializeField] private Transform snapTarget; 
    [SerializeField] private float snapDistance = 0.5f;
    [SerializeField] private string partName; 

    void Start()
    {
        
        startPosition = transform.position;

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (snapTarget == null)
        {
            Debug.LogError($"{gameObject.name}: Snap Target nie zosta³ przypisany w Inspector!");
        }
    }

    void OnMouseDown()
    {
        if (mainCamera == null) return;
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (mainCamera == null || !isDragging) return;
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (snapTarget == null) return;

        
        if (Vector3.Distance(transform.position, snapTarget.position) <= snapDistance)
        {
            
            if (partName == "CylinderHead" && !GameManager.Instance.isEngineBlockPlaced)
            {
                Debug.LogError("Nie mo¿na zamontowaæ g³owicy przed blokiem silnika!");
                ResetPosition();
                return;
            }

            
            transform.position = snapTarget.position;

            
            GameManager.Instance.PartPlaced(partName);
        }
        else
        {
            ResetPosition(); 
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void ResetPosition()
    {
        
        transform.position = startPosition;
    }
}
