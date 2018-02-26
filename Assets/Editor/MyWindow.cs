using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{

	static MyWindow window;

	string message = "消息";

	bool groupEnabled;
	bool mybool;
	float myfloat;
    [MenuItem("Window/MyWindow")]

    static void Init()
    {
        window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow), false, "MyWindow");
		window.autoRepaintOnSceneChange = true;
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField(EditorWindow.focusedWindow.ToString());
		// maximized = EditorGUILayout.ToggleLeft("Max",maximized);

		message = EditorGUILayout.TextField(message);
		if(GUILayout.Button("显示"))
		{
			window.ShowNotification(new GUIContent(message));
		}
		if (GUILayout.Button("不显示"))
		{
			window.RemoveNotification();
		}
		if (GUILayout.Button("关闭窗口"))
		{
			this.Close();
		}

		groupEnabled=EditorGUILayout.BeginToggleGroup("op",groupEnabled);

		mybool = EditorGUILayout.Toggle("Toggle",mybool);
		myfloat = EditorGUILayout.Slider("Slider",myfloat,-3,3);

		EditorGUILayout.EndToggleGroup();
    }

	void OnInspectorUpdate()
	{
		if (EditorWindow.mouseOverWindow)
		{
			EditorWindow.mouseOverWindow.Focus();
		}

		// this.Repaint();
	}
}
