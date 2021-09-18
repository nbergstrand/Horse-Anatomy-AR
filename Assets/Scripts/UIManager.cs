using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Failed to load UIManager");
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField]
    Animator _horseAnimator;

    [SerializeField]
    int _currentState;

    [SerializeField]
    GameObject _muscleLabel;

    [SerializeField]
    GameObject _boneLabel;

    private void Awake()
    {
        _instance = this;
    }

    public void NextState()
    {
        if(_currentState < 2)
        {
            _currentState++;
            _horseAnimator.SetInteger("CurrentState", _currentState);
        }

        EnableLabel(_currentState);

    }

    public void PreviousState()
    {
        if( _currentState > 0)
        {
            _currentState--;
            _horseAnimator.SetInteger("CurrentState", _currentState);
        }

        EnableLabel(_currentState);
    }


    void EnableLabel(int state)
    {
        switch (state)
        {
            case 1:
                _muscleLabel.SetActive(true);
                _boneLabel.SetActive(false);
                break;
            case 2:
                _muscleLabel.SetActive(false);
                _boneLabel.SetActive(true);
                break;

            default:
                _muscleLabel.SetActive(false);
                _boneLabel.SetActive(false);
                break;
        }

    }

    public void AssignModel(Animator animator, GameObject muscleLabel, GameObject boneLabel)
    {
        _horseAnimator = animator;
        _muscleLabel = muscleLabel;
        _boneLabel = boneLabel;
    }


}
