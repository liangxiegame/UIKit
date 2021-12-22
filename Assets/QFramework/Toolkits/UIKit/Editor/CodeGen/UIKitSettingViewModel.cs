using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QFramework
{
    public class UIKitSettingViewModel
    {

        private string mPanelNameToCreate = "UIHomePanel";

        public string PanelNameToCreate
        {
            get { return mPanelNameToCreate; }
            set { mPanelNameToCreate = value; }
        }
        
        public void OnCreateUIPanelClick()
        {

            var panelName = mPanelNameToCreate;

            if (!string.IsNullOrEmpty(panelName))
            {
                var fullScenePath = "Assets/Scenes/TestUIPanels/".CreateDirIfNotExists()
                    .Append("Test{0}.unity".FillFormat(panelName)).ToString();

                var panelPrefabPath = "Assets/Art/UIPrefab/".CreateDirIfNotExists()
                    .Append("{0}.prefab".FillFormat(panelName)).ToString();

                if (File.Exists(panelPrefabPath))
                {
                    EditorUtility.DisplayDialog("error", "UI 界面已存在:{0}".FillFormat(panelPrefabPath), "OK");
                    
                    return;
                }
                
                if (File.Exists(fullScenePath))
                {
                    
                    EditorUtility.DisplayDialog("error", "测试场景已存在:{0}".FillFormat(fullScenePath), "OK");
                    
                    return;
                }
                
                // RenderEndCommandExecutor.PushCommand(() =>
                // {
                //     var currentScene = SceneManager.GetActiveScene();
                //     EditorSceneManager.SaveScene(currentScene);
                //
                //     var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
                //     EditorSceneManager.SaveScene(scene, fullScenePath);
                //
                //     var uirootPrefab = Resources.Load<GameObject>("UIRoot");
                //         var uiroot = Object.Instantiate(uirootPrefab);
                //             uiroot.name = "UIRoot";
                //             
                //     var designTransform = uiroot.transform.Find("Design");
                //
                //     var gameObj = new GameObject(panelName);
                //     gameObj.transform.parent = designTransform;
                //     gameObj.transform.localScale = Vector3.one;
                //
                //     var rectTransform = gameObj.AddComponent<RectTransform>();
                //     rectTransform.offsetMin = Vector2.zero;
                //     rectTransform.offsetMax = Vector2.zero;
                //     rectTransform.anchoredPosition3D = Vector3.zero;
                //     rectTransform.anchorMin = Vector2.zero;
                //     rectTransform.anchorMax = Vector2.one;
                //
                //     var prefab = PrefabUtils.SaveAndConnect(panelPrefabPath, gameObj);
                //
                //     EditorSceneManager.SaveScene(scene);
                //
                //     // 标记 AssetBundle
                //     // ResKitAssetsMenu.MarkAB(panelPrefabPath);
                //
                //     var tester = new GameObject("Test{0}".FillFormat(panelName));
                //     // var uiPanelTester = tester.AddComponent<UIPanelTester>();
                //     // uiPanelTester.PanelName = panelName;
                //
                //     // 开始生成代码
                //     UICodeGenerator.DoCreateCode(new[] {prefab});
                // });
            }
        }
        
    }

    internal static class StringEx
    {
        /// <summary>
        /// 有点不安全,编译器不会帮你排查错误。
        /// </summary>
        /// <param name="selfStr"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FillFormat(this string selfStr, params object[] args)
        {
            return string.Format(selfStr, args);
        }
    }
}