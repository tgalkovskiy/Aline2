using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class SkillsPlayer : MonoBehaviour
{
    private Color _colorPrimary = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    private Color _colorSecondary = new Color(50 / 255f, 60 / 255f, 94 / 255f);
    [SerializeField] private ConfigurationPlayer _configurationPlayer = default;
    [SerializeField] private GameObject[] _listOfPerks = default;
    private List<int> _activePerks = new List<int> { };

    public void ShowDescriptionPerk(int index)
    {
        
    }
    
    public void TogglePerk(int index)
    {
        int perkIndex = _activePerks.IndexOf(index);
        if (perkIndex > -1)
        {
            _activePerks.RemoveAt(perkIndex);
            OffButtonEffect(_listOfPerks[index]);
        } else
        {
            _activePerks.Add(index);
            OnButtonEffect(_listOfPerks[index]);
        }
        switch (index)
        {
            case 0:
                _configurationPlayer.SetUpHp(perkIndex == -1);
                break;
            case 1:
                _configurationPlayer.SetUpAmmo(perkIndex == -1);
                break;
            case 2:
                _configurationPlayer.SetUpDamage(perkIndex == -1);
                break;
        }
    }

    private void OnButtonEffect(GameObject perkButton)
    {
        perkButton.GetComponent<Outline>().effectColor = _colorPrimary;
        perkButton.GetComponent<Image>().color = _colorSecondary;
    }
    private void OffButtonEffect(GameObject perkButton)
    {
        perkButton.GetComponent<Outline>().effectColor = _colorSecondary;
        perkButton.GetComponent<Image>().color = _colorPrimary;
    }
}
