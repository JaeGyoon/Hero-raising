//using UnityEditor;
//using UnityEngine;

//public class RuntimeAnimationCreator : MonoBehaviour
//{
//    public string resourcePath = "Sprites/Armored Axeman";
//    public string savePath = "Assets/05.Animations/Armored Axeman/SavedClip.anim";

//    void Start()
//    {
//        // Resources 폴더에서 스프라이트 로드
//        Sprite[] sprites = Resources.LoadAll<Sprite>(resourcePath);

//        if (sprites.Length > 0)
//        {
//            AnimationClip clip = new AnimationClip();
//            clip.frameRate = 60; // 초당 프레임 수
//            EditorCurveBinding curveBinding = new EditorCurveBinding();
//            curveBinding.type = typeof(SpriteRenderer);
//            curveBinding.path = "";
//            curveBinding.propertyName = "m_Sprite";

//            // 키프레임 설정
//            ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[sprites.Length];
//            for (int i = 0; i < sprites.Length; i++)
//            {
//                keyFrames[i] = new ObjectReferenceKeyframe();
//                keyFrames[i].time = i / clip.frameRate;
//                keyFrames[i].value = sprites[i];
//            }

//            AnimationUtility.SetObjectReferenceCurve(clip, curveBinding, keyFrames);

//            // 애니메이션 저장
//#if UNITY_EDITOR
//            AnimationSaver.SaveAnimationClip(clip, savePath);
//#endif
//        }
//        else
//        {
//            Debug.LogError("No sprites found at path: " + resourcePath);
//        }
//    }
//}