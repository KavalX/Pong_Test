using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int _pointsPlayer1 = 0;
    private int _pointsPlayer2 = 0;


    private HUDManager _HUDManager;

    public HUDManager HUDManager
    {
        get => _HUDManager;
        set => _HUDManager = value;
    }

    //Singleton

    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get => _instance;

    }

    private ball _ball;

    public ball Ball
    {

        get => _ball;
        set => _ball = value;

    }


    private GameManager()
    {

        if (_instance == null)
        {
            _instance = this;
        }

    }

    private void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(this);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        _HUDManager.setPoint(1, 0);
        _HUDManager.setPoint(2, 0);
    }

    public void AddPoint(int player)
    {
        if (player == 1)
        {
            _pointsPlayer1++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoint(1, _pointsPlayer1);
            }
        }

        else if (player == 2)
        {
            _pointsPlayer2++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoint(2, _pointsPlayer2);
            }
        }


        if (_ball != null)
        {
            _ball.Launch();
        }





    }


}

