using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Configuration Player", order = 0)]
public class ConfigurationPlayer : ScriptableObject
{
    public int health;
    public int damage;
    public int ammo;
    public int armor;
    public int exp;
    public bool hedgehog = false;
    public bool vampirism = false;
    public bool timeStop = false;
    public bool geneMode = false;
    public bool fineder = false;
    public bool viking = false;
    public bool nuclear = false;
    public bool spaunkiller = false;
    public bool insectKiller = false;
    public bool crioptic = false;
    public bool critmaster = false;
    public bool bigGun = false;
    public bool medalist = false;
    public bool coin = false;
    public bool education = false;
    public bool repair = false;
    

    [TextArea (4,6)]public string[] _description; 
    public void SetUpHp()
    {
        health = 150;
    }
    public void SetUpAmmo()
    {
        ammo = 150;
    }
    public void SetUpDamage()
    {
        damage = 25;
    }
    public void SetHedgehog()
    {
        hedgehog = true;
    }
    public void SetVampirism()
    {
        vampirism = true;
    }
    public void SetTimeStop()
    {
        timeStop = true;
    }
    public void SetGenemode()
    {
        geneMode = true;
    }
    public void SetFineder()
    {
        fineder = true;
    }
    public void SetRoboGolem()
    {
        armor += 60;
    }
    public void SetViking()
    {
        viking = true;
    }
    public void SetNuclear()
    {
        nuclear = true;
    }
    public void SetSpaunKiller()
    {
        spaunkiller = true;
    }
    public void SetInsectKiller()
    {
        insectKiller = true;
    }
    public void SetCrioptic()
    {
        crioptic = true;
    }
    public void SetcritMaster()
    {
        critmaster = true;
    }
    public void SetBigGun()
    {
        bigGun = true;
    }
    public void SetMedalist()
    {
        medalist = true;
    }
    public void SetCoin()
    {
        coin = true;
    }
    public void SetEducation()
    {
        education = true;
    }
    public void SetRepair()
    {
        repair = true;
    }
    public void SetDefault()
    {
        health = 100;
        ammo = 50;
        damage = 15;
        armor = 25;
        hedgehog = false;
        vampirism = false;
        timeStop = false;
        geneMode = false;
        fineder = false;
        viking = false;
        nuclear = false;
        spaunkiller = false;
        insectKiller = false;
        crioptic = false;
        critmaster = false;
        bigGun = false;
        medalist = false;
        coin = false;
        education = false;
        repair = false;
        
    }
}
