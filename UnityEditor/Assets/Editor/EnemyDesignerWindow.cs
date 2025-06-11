using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow
{
    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    private int count = 0;
    private void OnGUI()
    {
        GUILayout.Label("적에 관한 내용을 만드는 툴", EditorStyles.boldLabel);
        GUILayout.Label("그냥 일반 라벨");
        EditorGUILayout.LabelField("라벨필드:", "보스");

        GUILayout.Label("큐브만들기", EditorStyles.boldLabel);

        if(GUILayout.Button("Create Cube"))
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(count++ * 2, 0, 0);
            cube.transform.localScale = new Vector3(1, 1, 1);
            cube.name = "마법사";
            Debug.Log("큐브 생성됨");
        }
    }
}
