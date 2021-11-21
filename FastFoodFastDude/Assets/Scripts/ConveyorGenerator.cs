// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using UnityEditor.SceneManagement;
// using Collard;

// public class ConveyorGenerator : MonoBehaviour
// {
//     public GameObject Belt;

//     public GameObject End;

//     public GameObject Container;

//     public float width = 0.312f;

//     [SerializeField]
//     private int _length;
//     public int Length {
//         get => _length;
//         set {
//             if (value < 1) 
//             {
//                 return;
//             } 
//             this._length = value;
//             GenerateBelt();
//         }
//     }


//     public void GenerateBelt()
//     {
//         UnityUtils.DestroyImmediateChildren(Container.transform);
//         for (int i = 0; i < this.Length; i++)
//         {
//             GameObject belt = UnityEngine.Object.Instantiate<GameObject>(this.Belt);
//             belt.SetActive(true);
//             belt.transform.parent = Container.transform;
//             belt.transform.localPosition = new Vector2(width * i, 0);
//         }
//         GameObject end = UnityEngine.Object.Instantiate<GameObject>(this.End);
//         end.SetActive(true);
//         end.transform.parent = Container.transform;
//         end.transform.localPosition = new Vector2(width * this.Length, 0);
//     }
// }

// [CustomEditor(typeof(ConveyorGenerator))]
// public class ConveyorGeneratorEditor : Editor
// {

//     public override void OnInspectorGUI()
//     {

//         ConveyorGenerator generator = (ConveyorGenerator)target;
//         EditorGUI.BeginChangeCheck();

//         generator.Belt = (GameObject)EditorGUILayout.ObjectField("Belt", generator.Belt, typeof(GameObject), true);
//         generator.End = (GameObject)EditorGUILayout.ObjectField("End", generator.End, typeof(GameObject), true);
//         generator.Container = (GameObject)EditorGUILayout.ObjectField("Container", generator.Container, typeof(GameObject), true);
//         generator.Length = EditorGUILayout.IntField("Length", generator.Length);

//         if (EditorGUI.EndChangeCheck())
//         {
//             EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
//         }
//     }

// }