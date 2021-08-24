using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SkillsPlayer : MonoBehaviour
{
    [SerializeField] private ConfigurationPlayer _configurationPlayer = default;
    [SerializeField] private List<GameObject> _skillsImage = new List<GameObject>();
    [SerializeField] private Text _description = default;
    public void Started(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void ShowDescriptionPerk(int index)
    {
        _description.text = _configurationPlayer._description[index];
    }
    public void UnShowDescriptionPerk()
    {
        _description.text = "";
    }
    
    public void TogglePerk(int index)
    {
        for (int i = 0; i < _skillsImage.Count; i++)
        {
            if (i != index)
            {
                _skillsImage[i].transform.DOScale(Vector3.one, 0.2f);
                _skillsImage[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                _skillsImage[i].transform.DOScale(Vector3.one*1.2f, 0.2f); 
                _skillsImage[i].GetComponent<Image>().color = Color.green;
            }
        }
        _configurationPlayer.SetDefault();
        switch (index)
        {
            case 0:
                _configurationPlayer.SetUpHp();
                break;
            case 1: _configurationPlayer.SetUpAmmo();
                break;
            case 2: _configurationPlayer.SetUpDamage();
                break;
        }
        
    }
}
