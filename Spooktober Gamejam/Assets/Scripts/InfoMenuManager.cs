using CMF;
using UnityEngine;

public class InfoMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject infoMenuContainer;
    [SerializeField] private GameObject thoughtTextBox;
    private AdvancedWalkerController advancedWalkerController;
    private CameraController cameraController;
    private MainPlayer mainPlayer;
    private NotebookMenu notebookMenu;

    [SerializeField] private KeyCode infoMenuKey = KeyCode.F;

    private float initialMovementSpeed = 0;
    private float initialCameraSpeed = 0;
    public bool infoMenuOpen = false;

    private void Awake()
    {
        advancedWalkerController = GetComponent<AdvancedWalkerController>();
        cameraController = GetComponentInChildren<CameraController>();
        mainPlayer = GetComponent<MainPlayer>();
        notebookMenu = GetComponent<NotebookMenu>();
    }

    void Start()
    {
        infoMenuContainer.SetActive(false);
        initialCameraSpeed = cameraController.cameraSpeed;
        initialMovementSpeed = advancedWalkerController.movementSpeed;

        for (var i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(infoMenuKey) && infoMenuOpen)
        {
            DisableInfoMenu();
        } else if (Input.GetKeyDown(infoMenuKey) && !infoMenuOpen)
        {
            EnableInfoMenu();
        }

        if (infoMenuOpen && notebookMenu.notebookIsOpen)
        {
            notebookMenu.DisableNoteBook();
            EnableInfoMenu();
        }
    }

    public void DisableInfoMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        advancedWalkerController.movementSpeed = initialMovementSpeed;
        cameraController.cameraSpeed = initialCameraSpeed;
        mainPlayer.canInteract = true;
        infoMenuContainer.SetActive(false);
        infoMenuOpen = false;
    }

    public void EnableInfoMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        advancedWalkerController.movementSpeed = 0f;
        cameraController.cameraSpeed = 0f;
        mainPlayer.canInteract = false;
        infoMenuContainer.SetActive(true);
        infoMenuOpen = true;
        thoughtTextBox.SetActive(false);
    }

    public void ShowButton(int index)
    {
        buttons[index].SetActive(true);
    }
}
