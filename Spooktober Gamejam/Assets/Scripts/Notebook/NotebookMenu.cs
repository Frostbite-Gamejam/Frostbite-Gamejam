using CMF;
using TMPro;
using UnityEngine;

public class NotebookMenu : MonoBehaviour
{

    private AdvancedWalkerController advancedWalkerController;
    private CameraController cameraController;
    private MainPlayer mainPlayer;
    private InfoMenuManager infoMenuManager;

    //info menu
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject infoMenuContainer;
    [SerializeField] private GameObject thoughtTextBox;

    //notebook
    [SerializeField] private TMP_InputField firstInputField;
    [SerializeField] private GameObject notebookBackground;
    [SerializeField] private GameObject notebookUIParent;
    [SerializeField] private KeyCode notebookKey = KeyCode.Q;

    [SerializeField] private LevelManager firstLevel;
    [SerializeField] private LevelManager secondLevel;
    [SerializeField] private LevelManager thirdLevel;
    [SerializeField] private LevelManager forthLevel;
    [SerializeField] private LevelManager fifthLevel;

    [Header("Door Unlock Checks")]
    [SerializeField] private bool firstDoorUnlock = false;
    [SerializeField] private bool secondDoorUnlock = false;
    [SerializeField] private bool thirdDoorUnlock = false;
    [SerializeField] private bool fourthDoorUnlock = false;
    [SerializeField] private bool fifthDoorUnlock = false;

    public bool notebookIsOpen = false;
    private bool notebookHiddenFirstLevel = false;
    private bool notebookHiddenSecondLevel = false;
    private bool notebookHiddenThirdLevel = false;
    private bool notebookHiddenForthLevel = false;
    private bool notebookHiddenFifthLevel = false;
    private float initialCameraSpeed;
    private float initialMovementSpeed;

    private void Awake()
    {
        advancedWalkerController = GetComponent<AdvancedWalkerController>();
        cameraController = GetComponentInChildren<CameraController>();
        mainPlayer = GetComponent<MainPlayer>();
        infoMenuManager = GetComponent<InfoMenuManager>();
    }

    private void Start()
    {
        firstLevel.gameObject.SetActive(true);
        notebookBackground.SetActive(false);
        notebookUIParent.SetActive(false);
        initialCameraSpeed = cameraController.cameraSpeed;
        initialMovementSpeed = advancedWalkerController.movementSpeed;
    }

    private void Update()
    {
        if (firstLevel.levelIsClear)
        {
            firstLevel.gameObject.SetActive(false);
            secondLevel.gameObject.SetActive(true);
            if (!notebookHiddenFirstLevel)
            {
                DisableNoteBook();
                notebookHiddenFirstLevel = true;
            }
        }

        if (secondLevel.levelIsClear)
        {
            secondLevel.gameObject.SetActive(false);
            thirdLevel.gameObject.SetActive(true);
            if (!notebookHiddenSecondLevel)
            {
                DisableNoteBook();
                notebookHiddenSecondLevel = true;
            }
        }

        if (thirdLevel.levelIsClear)
        {
            thirdLevel.gameObject.SetActive(false);
            forthLevel.gameObject.SetActive(true);
            if (!notebookHiddenThirdLevel)
            {
                DisableNoteBook();
                notebookHiddenThirdLevel = true;
            }
        }

        if (forthLevel.levelIsClear)
        {
            forthLevel.gameObject.SetActive(false);
            fifthLevel.gameObject.SetActive(true);
            if (!notebookHiddenForthLevel)
            {
                DisableNoteBook();
                notebookHiddenForthLevel = true;
            }
        }

        if (fifthLevel.levelIsClear)
        {
            if (!notebookHiddenFifthLevel)
            {
                DisableNoteBook();
                notebookHiddenFifthLevel = true;
            }
        }

        if (Input.GetKeyDown(notebookKey) && notebookIsOpen)
        {
            DisableNoteBook();
        } else if (Input.GetKeyDown(notebookKey) && !notebookIsOpen)
        {
            EnableNoteBook();
        }

        if (notebookIsOpen && infoMenuManager.infoMenuOpen)
        {
            infoMenuManager.DisableInfoMenu();
            EnableNoteBook();
        }
    }

    public void DisableNoteBook()
    {
        Cursor.lockState = CursorLockMode.Locked;
        advancedWalkerController.movementSpeed = initialMovementSpeed;
        cameraController.cameraSpeed = initialCameraSpeed;
        mainPlayer.canInteract = true;
        notebookBackground.SetActive(false);
        notebookUIParent.SetActive(false);
        notebookIsOpen = false;
    }

    public void EnableNoteBook()
    {
        Cursor.lockState = CursorLockMode.None;
        advancedWalkerController.movementSpeed = 0f;
        cameraController.cameraSpeed = 0f;
        mainPlayer.canInteract = false;
        notebookBackground.SetActive(true);
        notebookUIParent.SetActive(true);
        notebookIsOpen = true;
    }

}
