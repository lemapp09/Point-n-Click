using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClick();
    }

    void OnClick()
    {
        RaycastHit hit;
        Ray camToScreen = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    MovePlayer(interactable.InteractPosition());
                    interactable.Interact(this);
                }
                else {
                    MovePlayer(hit.point);
                }
            }
        }
    }
    
    public bool CheckIfArrived() {
        return (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance);
    }

    void MovePlayer(Vector3 targetPosition) {
        _agent.SetDestination(targetPosition);
    }
}