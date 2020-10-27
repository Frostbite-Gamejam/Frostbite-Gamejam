using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class QuestionManager : MonoBehaviour
{
    private TMP_InputField tMP_InputField;

    [SerializeField] private string answer = "";
    public bool isQuestionComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        tMP_InputField = GetComponentInChildren<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tMP_InputField.text.Contains(answer.ToLower()))
        {
            isQuestionComplete = true;
        }
    }
}
