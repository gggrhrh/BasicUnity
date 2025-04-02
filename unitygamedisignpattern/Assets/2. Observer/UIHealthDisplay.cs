using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    void Start()
    {
        //
        EventManager.Instance.AddListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.RemoveListener("PlayerDied", OnPlayerDied);
    }

    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI 업데이트: 플레이어 체력이 {health}로 변경되었습니다.");
        //실제로는 여기서 UI요소를 업데이트합니다.
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI 업데이트: 플레이어가 사망했습니다!");
        //게임 오버 화면 표시 등의 동작 수행
    }

    void Update()
    {
        
    }
}
