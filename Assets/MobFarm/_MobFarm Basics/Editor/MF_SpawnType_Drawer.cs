using UnityEngine;
using UnityEditor;
using System.Collections;

// FS_LogicDrawer
[CustomPropertyDrawer (typeof (MF_B_Spawner.SpawnType))]
public class SpawnType : PropertyDrawer {

	int lh1 = 16; // line height

	public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
		int lines = 7;
		return (( lh1 + 2 ) * lines ) + 2; // (lines * line height) + padding
	}

	// Draw the property inside the given rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
		
		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		
		// Don't make child fields be indented
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float posY = position.y;
		int l1 = 0;

		// Calculate rects
		Rect labelUnitRect = 	new Rect ( position.x, 		posY+(lh1*l1), 		position.width, 		lh1 );
		l1++;
		Rect chanceRect = 		new Rect ( position.x, 		posY+(lh1*l1),  	30, 					lh1 );
		Rect unitRect = 		new Rect ( position.x+35, 	posY+(lh1*l1), 		position.width-35, 		lh1 );

		l1++;
		Rect labelFacRect = 	new Rect ( position.x, 		posY+(lh1*l1), 		position.width, 		lh1 );
		l1++;
		Rect overFacRect = 		new Rect ( position.x, 		posY+(lh1*l1), 		45, 					lh1 );
		Rect facRect = 			new Rect ( position.x+45, 	posY+(lh1*l1),		position.width-45, 		lh1 );

		l1++;
		Rect labelSpawnRect = 	new Rect ( position.x, 		posY+(lh1*l1), 		position.width, 		lh1 );
		l1++;
		Rect spawnRect = 		new Rect ( position.x, 		posY+(lh1*l1), 		position.width, 		lh1 );

		l1++;
		Rect labelWptRect = 	new Rect ( position.x, 		posY+(lh1*l1), 		position.width, 		lh1 );
		l1++;
		Rect wptRect = 			new Rect ( position.x, 		posY+(lh1*l1), 		150, 					lh1 );
		Rect randomWptRect = 	new Rect ( position.x+130, 	posY+(lh1*l1), 		position.width-130, 	lh1 );
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.LabelField( labelUnitRect, "Chance   Prefab", EditorStyles.miniLabel ); 
		EditorGUI.PropertyField( chanceRect, property.FindPropertyRelative ("chance"), GUIContent.none );
		EditorGUI.PropertyField( unitRect, property.FindPropertyRelative ("unit"), GUIContent.none );

		EditorGUI.indentLevel = 2;
		EditorGUI.LabelField( labelFacRect, "Override Faction?", EditorStyles.miniLabel ); 
		EditorGUI.PropertyField( overFacRect, property.FindPropertyRelative ("overrideFaction"), GUIContent.none );
		EditorGUI.PropertyField( facRect, property.FindPropertyRelative ("faction"), GUIContent.none );

		EditorGUI.LabelField( labelSpawnRect, "Alt Spawn Location", EditorStyles.miniLabel ); 
		EditorGUI.PropertyField( spawnRect, property.FindPropertyRelative ("spawn"), GUIContent.none );

		EditorGUI.LabelField( labelWptRect, "Alt WPT Group      Set Nav Random?", EditorStyles.miniLabel ); 
		EditorGUI.PropertyField( wptRect, property.FindPropertyRelative ("wpt"), GUIContent.none );
		EditorGUI.PropertyField( randomWptRect, property.FindPropertyRelative ("randomWpt"), GUIContent.none );
		
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		
		EditorGUI.EndProperty ();
	}
}

