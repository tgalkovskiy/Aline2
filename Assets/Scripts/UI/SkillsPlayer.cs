using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SkillsPlayer : MonoBehaviour
{
    [SerializeField] private ConfigurationPlayer _configurationPlayer = default;

    public void ShowDescriptionPerk(int index)
    {
        
    }
    
    public void TogglePerk(int index)
    {
        switch (index)
        {
            case 0: _configurationPlayer.SetUpHp();
                break;
            case 1: _configurationPlayer.SetUpAmmo();
                break;
            case 2: _configurationPlayer.SetUpDamage();
                break;
        }
    }
}
