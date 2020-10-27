using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private QuestionManager firstQuestion;
    [SerializeField] private QuestionManager secondQuestion;
    [SerializeField] private QuestionManager thirdQuestion;
    [SerializeField] private QuestionManager forthQuestion;
    [SerializeField] private QuestionManager fifthQuestion;

    public bool levelIsClear = false;

    // Update is called once per frame
    void Update()
    {
        if (firstQuestion.isQuestionComplete && 
            secondQuestion.isQuestionComplete &&
            thirdQuestion.isQuestionComplete &&
            forthQuestion.isQuestionComplete &&
            fifthQuestion.isQuestionComplete) {
            levelIsClear = true;
        }
    }
}
