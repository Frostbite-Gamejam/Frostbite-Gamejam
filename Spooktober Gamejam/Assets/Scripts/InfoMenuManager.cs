using CMF;
using UnityEngine;

public class InfoMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    private AdvancedWalkerController advancedWalkerController;
    private CameraController cameraController;
    private MainPlayer mainPlayer;

    [SerializeField] private GameObject infoMenuContainer;
    [SerializeField] private KeyCode infoMenuKey = KeyCode.F;

    private float initialMovementSpeed = 0;
    private float initialCameraSpeed = 0;
    private bool infoMenuOpen;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        advancedWalkerController = playerObject.GetComponent<AdvancedWalkerController>();
        cameraController = playerObject.GetComponentInChildren<CameraController>();
        mainPlayer = playerObject.GetComponent<MainPlayer>();
    }

    void Start()
    {
        infoMenuContainer.SetActive(false);
        initialCameraSpeed = cameraController.cameraSpeed;
        initialMovementSpeed = advancedWalkerController.movementSpeed;

        for (var i = 0; i <= buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(infoMenuKey) && infoMenuOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            advancedWalkerController.movementSpeed = initialMovementSpeed;
            cameraController.cameraSpeed = initialCameraSpeed;
            advancedWalkerController.jumpInputIsLocked = false;
            mainPlayer.canInteract = true;
            infoMenuContainer.SetActive(false);
            infoMenuOpen = false;
        } else if (Input.GetKeyDown(infoMenuKey) && !infoMenuOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            advancedWalkerController.movementSpeed = 0f;
            cameraController.cameraSpeed = 0f;
            advancedWalkerController.jumpInputIsLocked = true;
            mainPlayer.canInteract = false;
            infoMenuContainer.SetActive(true);
            infoMenuOpen = true;
        }
    }

    public void ShowButton(int index)
    {
        buttons[index].SetActive(true);
    }
}
