using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionScreenPlayer : MonoBehaviour
{
    [SerializeField] private Material[] skins;
    private MeshRenderer meshRenderer;
    private PlayerInput playerInput;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = skins[playerInput.playerIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
