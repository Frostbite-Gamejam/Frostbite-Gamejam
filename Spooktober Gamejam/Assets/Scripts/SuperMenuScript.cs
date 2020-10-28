using CMF;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuperMenuScript : MonoBehaviour
{
    private AdvancedWalkerController advancedWalkerController;
    private CameraController cameraController;
    private MainPlayer mainPlayer;
    private float initialCameraSpeed;
    private float initialMovementSpeed;

    //notebook
    [SerializeField] private GameObject notebookMenuContainer;
    [SerializeField] private KeyCode notebookKey;
    [SerializeField] private GameObject infoMenuContainer;
    [SerializeField] private KeyCode infoKey;
    [SerializeField] private GameObject pauseMenuContainer;
    [SerializeField] private KeyCode pauseKey;

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

    private bool notebookHiddenFirstLevel = false;
    private bool notebookHiddenSecondLevel = false;
    private bool notebookHiddenThirdLevel = false;
    private bool notebookHiddenForthLevel = false;
    private bool notebookHiddenFifthLevel = false;

    //info menu
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject thoughtTextBox;


    public bool isNotebookOpen = false;
    public bool isInfoOpen = false;
    public bool isPauseOpen = false;


    private void Awake()
    {
        advancedWalkerController = GetComponent<AdvancedWalkerController>();
        cameraController = GetComponentInChildren<CameraController>();
        mainPlayer = GetComponent<MainPlayer>();
    }

    private void Start()
    {
        firstLevel.gameObject.SetActive(true);
        notebookMenuContainer.SetActive(false);
        initialCameraSpeed = cameraController.cameraSpeed;
        initialMovementSpeed = advancedWalkerController.movementSpeed;

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
        if (firstLevel.levelIsClear)
        {
            firstLevel.gameObject.SetActive(false);
            secondLevel.gameObject.SetActive(true);
            if (!notebookHiddenFirstLevel)
            {
                //DisableNoteBook();
                notebookHiddenFirstLevel = true;
            }
            Debug.Log("First Level Is Clear");
        }

        if (secondLevel.levelIsClear)
        {
            secondLevel.gameObject.SetActive(false);
            thirdLevel.gameObject.SetActive(true);
            if (!notebookHiddenSecondLevel)
            {
                //DisableNoteBook();
                notebookHiddenSecondLevel = true;
            }
            Debug.Log("Second Level Is Clear");
        }

        if (thirdLevel.levelIsClear)
        {
            thirdLevel.gameObject.SetActive(false);
            forthLevel.gameObject.SetActive(true);
            if (!notebookHiddenThirdLevel)
            {
                //DisableNoteBook();
                notebookHiddenThirdLevel = true;
            }
            Debug.Log("Third Level Is Clear");
        }

        if (forthLevel.levelIsClear)
        {
            forthLevel.gameObject.SetActive(false);
            fifthLevel.gameObject.SetActive(true);
            if (!notebookHiddenForthLevel)
            {
                //DisableNoteBook();
                notebookHiddenForthLevel = true;
            }
            Debug.Log("Forth Level Is Clear");
        }

        if (fifthLevel.levelIsClear)
        {
            if (!notebookHiddenFifthLevel)
            {
                //DisableNoteBook();
                notebookHiddenFifthLevel = true;
            }
            Debug.Log("Fifth Level Is Clear You Have Completed The Game");
        }

        if (Input.GetKeyDown(notebookKey) && isNotebookOpen)
        {
            DisableMenu(notebookKey);
        }
        else if (Input.GetKeyDown(notebookKey) && (!isNotebookOpen && !isInfoOpen && !isPauseOpen))
        {
            EnableMenu(notebookKey);
        }
        else if (Input.GetKeyDown(infoKey) && isInfoOpen)
        {
            DisableMenu(infoKey);
        }
        else if (Input.GetKeyDown(infoKey) && (!isNotebookOpen && !isInfoOpen && !isPauseOpen))
        {
            EnableMenu(infoKey);
        }
        else if (Input.GetKeyDown(pauseKey) && isPauseOpen)
        {
            DisableMenu(pauseKey);
        }
        else if (Input.GetKeyDown(pauseKey) && (!isNotebookOpen && !isInfoOpen && !isPauseOpen))
        {
            EnableMenu(pauseKey);
        }
    }

    public void DisableMenu(KeyCode key)
    {
        Cursor.lockState = CursorLockMode.Locked;
        advancedWalkerController.movementSpeed = initialMovementSpeed;
        cameraController.cameraSpeed = initialCameraSpeed;
        mainPlayer.canInteract = true;
        if (key == notebookKey)
        {
            notebookMenuContainer.SetActive(false);
            isNotebookOpen = false;
        }
        if (key == infoKey)
        {
            infoMenuContainer.SetActive(false);
            isInfoOpen = false;
        }
        if (key == pauseKey)
        {
            pauseMenuContainer.SetActive(false);
            isPauseOpen = false;
        }
    }

    public void EnableMenu(KeyCode key)
    {
        Cursor.lockState = CursorLockMode.None;
        advancedWalkerController.movementSpeed = 0f;
        cameraController.cameraSpeed = 0f;
        mainPlayer.canInteract = false;
        thoughtTextBox.SetActive(false);
        if (key == notebookKey)
        {
            notebookMenuContainer.SetActive(true);
            isNotebookOpen = true;
        }
        if (key == infoKey)
        {
            infoMenuContainer.SetActive(true);
            isInfoOpen = true;
        }
        if (key == pauseKey)
        {
            pauseMenuContainer.SetActive(true);
            isPauseOpen = true;
        }
    }
}
