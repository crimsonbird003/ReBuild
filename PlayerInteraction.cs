using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableMask;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode attackKeyAlt = KeyCode.Mouse0;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableMask))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Show UI prompt (e.g., "Press E to interact")
                UIManager.Instance.ShowPrompt("Press E to interact");

                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }
            }

            IAttackable attackable = hit.collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                // Show UI prompt (e.g., "Press F to attack")
                UIManager.Instance.ShowPrompt("Press F to attack");

                if (Input.GetKeyDown(attackKey))
                {
                    attackable.Attack();
                }
            }
        }
        else
        {
            UIManager.Instance.HidePrompt();
        }
    }
}

public interface IInteractable
{
    void Interact();
}

public interface IAttackable
{
    void Attack();
}