using CMF;
using TMPro;
using UnityEngine;

public class NotebookMenu : MonoBehaviour
{
    private AdvancedWalkerController advancedWalkerController;
    private CameraController cameraController;
    private MainPlayer mainPlayer;
    [SerializeField] private TMP_InputField firstInputField;
    [SerializeField] private GameObject notebookBackground;
    [SerializeField] private GameObject notebookUIParent;
    [SerializeField] private KeyCode notebookKey = KeyCode.Q;

    [Header("Questions")]
    [SerializeField] private string Q1 = "";
    [SerializeField] private string Q2 = "";
    [SerializeField] private string Q3 = "";
    [SerializeField] private string Q4 = "";
    [SerializeField] private string Q5 = "";
    [SerializeField] private string Q6 = "";
    [SerializeField] private string Q7 = "";
    [SerializeField] private string Q8 = "";
    [SerializeField] private string Q9 = "";
    [SerializeField] private string Q10 = "";
    [SerializeField] private string Q11 = "";
    [SerializeField] private string Q12 = "";
    [SerializeField] private string Q13 = "";
    [SerializeField] private string Q14 = "";
    [SerializeField] private string Q15 = "";
    [SerializeField] private string Q16 = "";
    [SerializeField] private string Q17 = "";
    [SerializeField] private string Q18 = "";
    [SerializeField] private string Q19 = "";
    [SerializeField] private string Q20 = "";
    [SerializeField] private string Q21 = "";
    [SerializeField] private string Q22 = "";
    [SerializeField] private string Q23 = "";
    [SerializeField] private string Q24 = "";
    [SerializeField] private string Q25 = "";


    [Header("Answers")]
    [SerializeField] private string A1 = "";
    [SerializeField] private string A2 = "";
    [SerializeField] private string A3 = "";
    [SerializeField] private string A4 = "";
    [SerializeField] private string A5 = "";
    [SerializeField] private string A6 = "";
    [SerializeField] private string A7 = "";
    [SerializeField] private string A8 = "";
    [SerializeField] private string A9 = "";
    [SerializeField] private string A10 = "";
    [SerializeField] private string A11 = "";
    [SerializeField] private string A12 = "";
    [SerializeField] private string A13 = "";
    [SerializeField] private string A14 = "";
    [SerializeField] private string A15 = "";
    [SerializeField] private string A16 = "";
    [SerializeField] private string A17 = "";
    [SerializeField] private string A18 = "";
    [SerializeField] private string A19 = "";
    [SerializeField] private string A20 = "";
    [SerializeField] private string A21 = "";
    [SerializeField] private string A22 = "";
    [SerializeField] private string A23 = "";
    [SerializeField] private string A24 = "";
    [SerializeField] private string A25 = "";

    [Header("Answer Checks")]
    [SerializeField] private bool C1 = false;
    [SerializeField] private bool C2 = false;
    [SerializeField] private bool C3 = false;
    [SerializeField] private bool C4 = false;
    [SerializeField] private bool C5 = false;
    [SerializeField] private bool C6 = false;
    [SerializeField] private bool C7 = false;
    [SerializeField] private bool C8 = false;
    [SerializeField] private bool C9 = false;
    [SerializeField] private bool C10 = false;
    [SerializeField] private bool C11 = false;
    [SerializeField] private bool C12 = false;
    [SerializeField] private bool C13 = false;
    [SerializeField] private bool C14 = false;
    [SerializeField] private bool C15 = false;
    [SerializeField] private bool C16 = false;
    [SerializeField] private bool C17 = false;
    [SerializeField] private bool C18 = false;
    [SerializeField] private bool C19 = false;
    [SerializeField] private bool C20 = false;
    [SerializeField] private bool C21 = false;
    [SerializeField] private bool C22 = false;
    [SerializeField] private bool C23 = false;
    [SerializeField] private bool C24 = false;
    [SerializeField] private bool C25 = false;

    [Header("Door Unlock Checks")]
    [SerializeField] private bool firstDoorUnlock = false;
    [SerializeField] private bool secondDoorUnlock = false;
    [SerializeField] private bool thirdDoorUnlock = false;
    [SerializeField] private bool fourthDoorUnlock = false;
    [SerializeField] private bool fifthDoorUnlock = false;

    private bool notebookIsOpen = false;
    private float initialCameraSpeed;
    private float initialMovementSpeed;

    private void Awake()
    {
        advancedWalkerController = GetComponent<AdvancedWalkerController>();
        cameraController = GetComponentInChildren<CameraController>();
        mainPlayer = GetComponent<MainPlayer>();
    }

    private void Start()
    {
        notebookBackground.SetActive(false);
        notebookUIParent.SetActive(false);
        initialCameraSpeed = cameraController.cameraSpeed;
        initialMovementSpeed = advancedWalkerController.movementSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(notebookKey) && notebookIsOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            advancedWalkerController.movementSpeed = initialMovementSpeed;
            cameraController.cameraSpeed = initialCameraSpeed;
            mainPlayer.canInteract = true;
            notebookBackground.SetActive(false);
            notebookUIParent.SetActive(false);
            notebookIsOpen = false;
        } else if (Input.GetKeyDown(notebookKey) && !notebookIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            advancedWalkerController.movementSpeed = 0f;
            cameraController.cameraSpeed = 0f;
            mainPlayer.canInteract = false;
            notebookBackground.SetActive(true);
            notebookUIParent.SetActive(true);
            notebookIsOpen = true;
        }

        C1  = firstInputField.text.Contains(A1) ? C1  = true : C1  = false;
        C2  = firstInputField.text.Contains(A2) ? C2  = true : C2  = false;
        C3  = firstInputField.text.Contains(A3) ? C3  = true : C3  = false;
        C4  = firstInputField.text.Contains(A4) ? C4  = true : C4  = false;
        C5  = firstInputField.text.Contains(A5) ? C5  = true : C5  = false;
        C6  = firstInputField.text.Contains(A6) ? C6  = true : C6  = false;
        C7  = firstInputField.text.Contains(A7) ? C7  = true : C7  = false;
        C8  = firstInputField.text.Contains(A8) ? C8  = true : C8  = false;
        C9  = firstInputField.text.Contains(A9) ? C9  = true : C9  = false;
        C10 = firstInputField.text.Contains(A10) ? C10 = true : C10 = false;
        C11 = firstInputField.text.Contains(A11) ? C11 = true : C11 = false;
        C12 = firstInputField.text.Contains(A12) ? C12 = true : C12 = false;
        C13 = firstInputField.text.Contains(A13) ? C13 = true : C13 = false;
        C14 = firstInputField.text.Contains(A14) ? C14 = true : C14 = false;
        C15 = firstInputField.text.Contains(A15) ? C15 = true : C15 = false;
        C16 = firstInputField.text.Contains(A16) ? C16 = true : C16 = false;
        C17 = firstInputField.text.Contains(A17) ? C17 = true : C17 = false;
        C18 = firstInputField.text.Contains(A18) ? C18 = true : C18 = false;
        C19 = firstInputField.text.Contains(A19) ? C19 = true : C19 = false;
        C20 = firstInputField.text.Contains(A20) ? C20 = true : C20 = false;
        C21 = firstInputField.text.Contains(A21) ? C21 = true : C21 = false;
        C22 = firstInputField.text.Contains(A22) ? C22 = true : C22 = false;
        C23 = firstInputField.text.Contains(A23) ? C23 = true : C23 = false;
        C24 = firstInputField.text.Contains(A24) ? C24 = true : C24 = false;
        C25 = firstInputField.text.Contains(A25) ? C25 = true : C25 = false;

        if (C1 && C2 && C3 && C4 && C5)
        {
            firstDoorUnlock = true;
        }

        if (C6 && C7 && C8 && C9 && C10)
        {
            secondDoorUnlock = true;
        }

        if (C11 && C12 && C13 && C14 && C15)
        {
            thirdDoorUnlock = true;
        }

        if (C16 && C17 && C18 && C19 && C20)
        {
            fourthDoorUnlock = true;
        }

        if (C21 && C22 && C23 && C24 && C25)
        {
            fifthDoorUnlock = true;
        }
    }

}
