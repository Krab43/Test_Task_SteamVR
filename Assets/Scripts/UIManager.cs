using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [Header("Buttons")] 
    [SerializeField] private GameManager gameManager;

    [Header("Buttons")] 
    [SerializeField] private SVR_ButtonScript vrCubeBtn;
    [SerializeField] private SVR_ButtonScript vrSphereBtn;
    [SerializeField] private SVR_ButtonScript vrCylinderBtn;
    [SerializeField] private SVR_ButtonScript vrClearBtn;

    [Space] 
    [SerializeField] private AudioManager audioManager;

    private int _scoreCount = 0;
    public static UIManager Instance { get; private set; }

    void Start()
    {
        vrCubeBtn.OnPressed.AddListener(() => SpawnObjectOnClick(0));
        vrSphereBtn.OnPressed.AddListener(() => SpawnObjectOnClick(1));
        vrCylinderBtn.OnPressed.AddListener(() => SpawnObjectOnClick(2));
        vrClearBtn.OnPressed.AddListener(ClearPrefabs);
    }

    public void ClearPrefabs()
    {
        gameManager.ClearSpawnedPrefabs();
    }

    public void SpawnObjectOnClick(int index)
    {
        gameManager.SpawnPrefab(index);
    }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        scoreText.text = _scoreCount.ToString();
    }

    public void ScoreUpdate()
    {
        _scoreCount++;
        scoreText.text = _scoreCount.ToString();
    }
}
