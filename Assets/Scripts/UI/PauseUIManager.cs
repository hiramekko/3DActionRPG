using UnityEngine;

/// <summary>
/// ポーズ時にポーズしているかを確認するUIの表示
/// </summary>
public class PauseUIManager : MonoBehaviour
{
    [SerializeField] Animator _pauseAnimator = default;
    PauseManager _pm = default;

    void Awake()
    {
        _pm = GameObject.FindObjectOfType<PauseManager>();
    }

    void OnEnable()
    {
        _pm.OnPauseResume += ShowMessage;
    }

    void OnDisable()
    {
        _pm.OnPauseResume -= ShowMessage;
    }

    void ShowMessage(bool isPause)
    {
        if (isPause)
        {
            _pauseAnimator.Play("Pause");
            Debug.Log("ポーズ中");
        }
        else
        {
            _pauseAnimator.Play("Resume");
            Debug.Log("再開");
        }
    }
}
