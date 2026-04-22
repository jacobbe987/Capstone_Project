using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask terrain;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundDistance;
    private bool IsGrounded = true;

    public bool CheckIsGrounded() => IsGrounded;

    private void Awake()
    {
        if (terrain == 0)
            terrain = LayerMask.GetMask("Terrain");
    }

    private void OnDrawGizmos()
    {
        if (groundChecker == null) return;
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundChecker.position, groundDistance);
    }

    private void FixedUpdate()
    {
        if (groundChecker == null) return;
        IsGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, terrain, QueryTriggerInteraction.Ignore);
    }
}