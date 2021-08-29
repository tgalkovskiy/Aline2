using System;
using System.IO;
using UnityEngine;

public class Data
{
    public int health;
    public int damage;
    public int ammo;
    public int armor;
    public int exp;
    public bool hedgehog;
    public bool vampirism;
    public bool timeStop; 
    public bool geneMode;
    public bool fineder;
    public bool viking;
    public bool nuclear;
    public bool spaunkiller;
    public bool insectKiller;
    public bool crioptic;
    public bool critmaster;
    public bool bigGun;
    public bool medalist;
    public bool coin;
    public bool education;
    public bool repair;
}

[CreateAssetMenu(fileName = "Player", menuName = "Configuration Player", order = 0)]
public class ConfigurationPlayer : ScriptableObject
{
    public int  health;
    public int  damage;
    public int  ammo;
    public int  armor;
    public int  exp;
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

    public void Save()
    {
        Data _data = new Data();
        _data.health=health;
        _data.damage=damage;
        _data.ammo=ammo;
        _data.armor=armor;
        _data.exp=exp;
        _data.hedgehog=hedgehog;
        _data.vampirism =vampirism;
        _data.timeStop=timeStop;
        _data.geneMode=geneMode;
        _data.fineder=fineder;
        _data.viking=viking;
        _data.nuclear=nuclear;
        _data.spaunkiller=spaunkiller;
        _data.insectKiller=insectKiller;
        _data.crioptic=crioptic;
        _data.critmaster=critmaster;
        _data.bigGun=bigGun;
        _data.medalist=medalist;
        _data.coin=coin;
        _data.education=education;
        _data.repair=repair;
        try
        {
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "AlienSave.Json"), JsonUtility.ToJson(_data));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    public void Load()
    {
        if (HasSave())
        {
            Data _data = new Data();
            _data = JsonUtility.FromJson<Data>(File.ReadAllText(Path.Combine(Application.persistentDataPath, "AlienSave.Json")));
            health = _data.health;
            damage = _data.damage;
            ammo = _data.ammo;
            armor = _data.armor;
            exp = _data.exp;
            hedgehog = _data.hedgehog;
            vampirism = _data.vampirism;
            timeStop = _data.timeStop;
            geneMode = _data.geneMode;
            fineder = _data.fineder;
            viking = _data.viking;
            nuclear = _data.nuclear;
            spaunkiller = _data.spaunkiller;
            insectKiller = _data.insectKiller;
            crioptic = _data.crioptic;
            critmaster = _data.critmaster;
            bigGun = _data.bigGun;
            medalist = _data.medalist;
            coin = _data.coin;
            education = _data.education;
            repair = _data.repair;
        }
        else
        {
            Debug.Log("file not exists");
        }
    }

    public bool HasSave() => File.Exists(Path.Combine(Application.persistentDataPath, "AlienSave.Json"));
}
