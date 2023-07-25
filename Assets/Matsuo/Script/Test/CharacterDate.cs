using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterDate", menuName = "ScriptableObjects/CharacterDate")]
public class CharacterDate : ScriptableObject
{
    [SerializeField, Tooltip("")]
    private string _characterName;
    [SerializeField, Tooltip("")]
    private Image _characterImage;


    [SerializeField, Tooltip("")]
    private int _maxHp;
    [SerializeField, Tooltip("")]
    private int _currentHp;
    [SerializeField, Tooltip("")]
    private int _atk;
    [SerializeField, Tooltip("")]
    private int _speed;
    [SerializeField, Tooltip("")]
    private int _def;

    [SerializeField, Tooltip("")]
    private int _maxLevel;
    [SerializeField, Tooltip("")]
    private int _currentLevel;

    [SerializeField, Tooltip("")]
    private float _currentExp;
    [SerializeField, Tooltip("")]
    private float _maxExp;

    public Image CharacterImage { get => _characterImage;}
    public string CharacterName { get => _characterName;}
    public int MaxHp { get => _maxHp;}
    public int CurrentHp { get => _currentHp; }
    public int Atk { get => _atk; }
    public int Speed { get => _speed; }
    public int Def { get => _def; }
    public int MaxLevel { get => _maxLevel; }
    public int CurrentLevel { get => _currentLevel; }
    public float CurrentExp { get => _currentExp; }
    public float MaxExp { get => _maxExp; }

}
