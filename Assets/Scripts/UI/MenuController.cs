using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _choiceSkills = default;
    public void ChoiceSkills()
    {
        _choiceSkills.SetActive(true);
        
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    
}
