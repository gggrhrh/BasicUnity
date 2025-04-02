using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeController : MonoBehaviour
{
    private static TimeController instance;

    public static TimeController Instance { get { return instance; } }

    public float slowMotionTimeScale = 0.3f;
    public float slowMotuinDuration = 0.5f; //슬로우 모션 지속시간
    private float slowMotionTimer = 0f;     //슬로우 모션 타이머

    public bool isSlowMotion { get; private set; }

    [Header("Post Processing")]
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ColorGrading colorGrading;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);  //맵이 변경되어도 파괴되지 않음
        }
        
    }

    void Start()
    {    
        //Post Processing 컴포넌트 가져오기
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);//post processing
    }

    void Update()
    {
        if(isSlowMotion)
        {
            slowMotionTimer += Time.deltaTime;
            if (slowMotionTimer >= slowMotuinDuration)
            {
                SetSlowMotion(false);
                slowMotionTimer = 0f;
            }
        }

    }

    //슬로우 효과에 사용하기
    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeScale : 1f; //슬로우 모션 중이면 slowMotionTimeScale 반환, 아니면 1f 반환
    }

    public void SetSlowMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            // 슬로우 모션 시작 시 효과 설정
            slowMotionTimer = 0f;
            vignette.intensity.value = 0.8f;         // 비네트 강도 대폭 증가
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // 채도 더욱 낮게
            colorGrading.temperature.value = -25f;    // 매우 차가운 색감
            colorGrading.contrast.value = 20f;        // 대비 더 강하게
            colorGrading.postExposure.value = -1.0f;  // 전체적으로 더 어둡게
            colorGrading.tint.value = 10f;           // 약간의 초록빛 추가
        }
        else
        {
            // 슬로우 모션 종료 시 효과 초기화
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}
