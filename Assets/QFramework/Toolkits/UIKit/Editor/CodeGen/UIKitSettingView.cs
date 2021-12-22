/****************************************************************************
 * Copyright 2019.1 ~ 2020.10 liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 ****************************************************************************/


using System;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace QFramework
{
    public class UIKitSettingView 
    {
        private UIKitSettingData mUiKitSettingData;
        


        private UIKitSettingViewModel mViewModel;

        public void Init()
        {
            mUiKitSettingData = UIKitSettingData.Load();

            mViewModel = new UIKitSettingViewModel();

        }

        private Lazy<GUIStyle> mLabelBold12 = new Lazy<GUIStyle>(() =>
        {
            return new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold
            };
        });
        
        private Lazy<GUIStyle> mLabel12 = new Lazy<GUIStyle>(() =>
        {
            return new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
            };
        });

        public void OnGUI()
        {
            
            GUILayout.BeginVertical("box");
            GUILayout.Label(LocaleText.Namespace,mLabel12.Value,GUILayout.Width(200));

            GUILayout.Space(6);

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LocaleText.Namespace,mLabelBold12.Value,GUILayout.Width(200));

                mUiKitSettingData.Namespace =  EditorGUILayout.TextField(mUiKitSettingData.Namespace);

            }
            
            GUILayout.Space(6);

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LocaleText.UIScriptGenerateDir,mLabelBold12.Value,GUILayout.Width(200));

                mUiKitSettingData.UIScriptDir = EditorGUILayout.TextField(mUiKitSettingData.UIScriptDir);

            }
            
            GUILayout.Space(6);

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LocaleText.UIPanelPrefabDir,mLabelBold12.Value,GUILayout.Width(200));

                mUiKitSettingData.UIPrefabDir = EditorGUILayout.TextField(mUiKitSettingData.UIPrefabDir);

            }
            
            GUILayout.Space(12);

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label(LocaleText.ViewControllerScriptGenerateDir,mLabelBold12.Value,GUILayout.Width(220));

                mUiKitSettingData.DefaultViewControllerScriptDir = EditorGUILayout.TextField(mUiKitSettingData.DefaultViewControllerScriptDir);

            }
            GUILayout.EndHorizontal();
            
            GUILayout.Space(6);

            
            GUILayout.BeginHorizontal();
            {
                
                GUILayout.Label(LocaleText.ViewControllerPrefabGenerateDir,mLabelBold12.Value,GUILayout.Width(220));
                mUiKitSettingData.DefaultViewControllerPrefabDir = EditorGUILayout.TextField(mUiKitSettingData.DefaultViewControllerPrefabDir);

            }
                GUILayout.EndHorizontal();

            GUILayout.Space(6);
            
            if (GUILayout.Button(LocaleText.Apply))
            {
                mUiKitSettingData.Save();
            }
            
            // mViewModel.PanelNameToCreate = EditorGUILayout.TextField(mViewModel.PanelNameToCreate);
            //
            // if (GUILayout.Button(LocaleText.CreateUIPanel))
            // {
            //     mViewModel.OnCreateUIPanelClick();
            // }
            GUILayout.EndVertical();
        }

        public void OnDispose()
        {
        }

        public new void OnShow()
        {
            
        }

        public new void OnHide()
        {
            
        }

        class LocaleText
        {
            public static string Namespace
            {
                get { return Language.IsChinese ? " 默认命名空间:" : " Namespace:"; }
            }

            public static string UIScriptGenerateDir
            {
                get { return Language.IsChinese ? " UI 脚本生成路径:" : " UI Scripts Generate Dir:"; }
            }

            public static string UIPanelPrefabDir
            {
                get { return Language.IsChinese ? " UIPanel Prefab 路径:" : " UIPanel Prefab Dir:"; }
            }

            public static string ViewControllerScriptGenerateDir
            {
                get { return Language.IsChinese ? " ViewController 脚本生成路径:" : " Default ViewController Generate Dir:"; }
            }

            public static string ViewControllerPrefabGenerateDir
            {
                get
                {
                    return Language.IsChinese
                        ? " ViewController Prefab 生成路径:"
                        : " Default ViewController Prefab Dir:";
                }
            }

            public static string Apply
            {
                get { return Language.IsChinese ? "保存" : "Apply"; }
            }

            public static string UIKitSettings
            {
                get { return Language.IsChinese ? "UI Kit 设置" : "UI Kit Settings"; }
            }

            public static string CreateUIPanel
            {
                get { return Language.IsChinese ? "创建 UI Panel" : "Create UI Panel"; }
            }
        }
    }
    internal class Language
    {
        public static bool IsChinese
        {
            get
            {
                return Application.systemLanguage == SystemLanguage.Chinese ||
                       Application.systemLanguage == SystemLanguage.ChineseSimplified;
            }
        }
    }
}