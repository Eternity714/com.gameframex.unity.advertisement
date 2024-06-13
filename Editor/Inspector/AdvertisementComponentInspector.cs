//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFrameX.Advertisement.Runtime;
using GameFrameX.Editor;
using UnityEditor;
using UnityEngine;

namespace GameFrameX.Advertisement.Editor
{
    [CustomEditor(typeof(AdvertisementComponent))]
    internal sealed class AdvertisementComponentInspector : ComponentTypeComponentInspector
    {
        private SerializedProperty m_adUnitId = null;
        private GUIContent m_adUnitIdGUIContent = new GUIContent("广告位ID");

        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode & Application.isPlaying);
            {
                EditorGUILayout.PropertyField(m_adUnitId, m_adUnitIdGUIContent);
            }
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }
        
        protected override void RefreshTypeNames()
        {
            RefreshComponentTypeNames(typeof(IAdvertisementManager));
        }

        protected override void Enable()
        {
            m_adUnitId = serializedObject.FindProperty("m_adUnitId");
        }
    }
}