using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private ConfigurationPlayer _configurationPlayer = default;
    [SerializeField] private GameObject _choiceSkills = default;
    [SerializeField] private GameObject _resumeButton = default;

    private void Awake()
    {
        if (_configurationPlayer.HasSave())
        {
            _resumeButton.SetActive(true);
        }
    }
    public void ChoiceSkills()
    {
        _choiceSkills.SetActive(true);
        
    }
    public void Play(int scene = 1)
    {
        SceneManager.LoadScene(scene > 0 ? scene : 1);
    }

    public void Resume()
    {
        _configurationPlayer.Load();
        Play();
    }
    
}
