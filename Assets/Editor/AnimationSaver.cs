//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using UnityEditor;

//public class AnimationSaver
//{
//    public static void SaveAnimationClip(AnimationClip clip, string path)
//    {
//        if (clip != null)
//        {
//            // 경로가 존재하지 않으면 생성
//            string directory = Path.GetDirectoryName(path);
//            if (!Directory.Exists(directory))
//            {
//                Directory.CreateDirectory(directory);
//            }

//            // 애니메이션 클립 저장
//            AssetDatabase.CreateAsset(clip, path);
//            AssetDatabase.SaveAssets();

//            Debug.Log("Animation Clip saved at: " + path);
//        }
//        else
//        {
//            Debug.LogError("No Animation Clip to save.");
//        }
//    }
//}