using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(SpawnMega))]
public class CustomSpawnInspector : Editor
{
	
	public GameObject[] Ob;

	public int numberOfObs;



	public override void OnInspectorGUI ()
	{
		numberOfObs = PlayerPrefs.GetInt ("numObs");
		
		SpawnMega S = target as SpawnMega;
		EditorUtility.SetDirty (S);
		Ob = new GameObject[numberOfObs];
	
		if (GUILayout.Button (new GUIContent ("Enable/Disable Spawner", "Turn Script On Or Off"))) {
			S.Spawn = !S.Spawn;
		}

		if (S.Spawn) {
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
		
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Player", "Player Object Section"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			GUILayout.BeginHorizontal ();
			EditorGUILayout.PrefixLabel (new GUIContent ("Player Object:", "Player GameObject Goes Here"));
			S.player = (GameObject)EditorGUILayout.ObjectField (S.player, typeof(GameObject), true);
			GUILayout.EndHorizontal ();

			GUILayout.Label ("");
			GUILayout.BeginHorizontal ();
			S.waitForDead = EditorGUILayout.Toggle (new GUIContent ("Wait For Player Respawn", "If Checked Spawning Will Stop When The Player Is Dead"), S.waitForDead);
			GUILayout.EndHorizontal ();

			GUILayout.Label ("");
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });


			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Spawn Objects", "Object Section"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			GUILayout.BeginHorizontal ();

			EditorGUILayout.PrefixLabel (new GUIContent ("Current Spawn Object", "This Is The Object Currently Set To Spawn, This Value Changes Depending On The Number Of Objects Set Below."));
			EditorGUI.BeginDisabledGroup (S.readOnly);
			S.ObSingle = (GameObject)EditorGUILayout.ObjectField (S.ObSingle, typeof(GameObject), true);
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			EditorGUI.EndDisabledGroup ();
			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();
			EditorGUILayout.PrefixLabel (new GUIContent ("Number of Objects", "Will Randomly Pick One Of These Objects To Spawn Each Spawn, Unless 0 Then Will Spawn Current Spawn Object"));

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			numberOfObs = EditorGUILayout.IntSlider (numberOfObs, 0, 10);
			GUILayout.EndVertical ();
			PlayerPrefs.SetInt ("numObs", numberOfObs);



			GUILayout.EndHorizontal ();


			for (int i = 1; i < Ob.Length + 1; i++) {

				if (i == 1) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle1 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle1, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 2) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle2 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle2, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 3) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle3 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle3, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 4) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle4 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle4, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 5) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle5 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle5, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 6) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle6 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle6, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 7) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle7 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle7, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 8) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle8 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle8, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 9) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle9 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle9, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				if (i == 10) {	
					GUILayout.BeginHorizontal ();
					GUILayout.BeginVertical ();
					EditorGUILayout.PrefixLabel ("Object " + i);
					GUILayout.EndVertical ();
					S.ObSingle10 = (GameObject)EditorGUILayout.ObjectField (S.ObSingle10, typeof(GameObject), true);
					GUILayout.EndHorizontal ();
				}
				S.numberOfObjects = numberOfObs;
			
			}
			GUILayout.Label ("");
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Spawn Frequency", "Rate Of Spawn"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			S.singleSpawn = EditorGUILayout.Toggle (new GUIContent ("Spawn Only Once", "Spawns Object Only One Time"), S.singleSpawn);
		
		
			GUILayout.Label ("");
		
			if (!S.singleSpawn) {
				if (!S.WaveSpawning) {
					S.RandomspawnBetweenTime = EditorGUILayout.Toggle (new GUIContent ("Random Time Between Spawns", "A Random Time Between Spawns"), S.RandomspawnBetweenTime);
				
					if (!S.RandomspawnBetweenTime) {
						GUILayout.Label ("");
						EditorGUILayout.BeginHorizontal ();
						EditorGUILayout.PrefixLabel (new GUIContent ("Time Between Spawns", "Delay Between Each Spawn In Seconds"));
						S.timeBetweenSpawns = EditorGUILayout.FloatField (S.timeBetweenSpawns);
						EditorGUILayout.LabelField (" Seconds");
						EditorGUILayout.EndHorizontal ();
				
					}
			
					if (S.RandomspawnBetweenTime) {
						GUILayout.Label ("");
						EditorGUILayout.BeginHorizontal ();
						EditorGUILayout.PrefixLabel (new GUIContent ("Minimum Time Between Spawns", "Minimum Seconds Delay For Each Spawn"));
						S.randomTimeBetweenSpawnsMin = EditorGUILayout.FloatField (S.randomTimeBetweenSpawnsMin);
						EditorGUILayout.LabelField (" Seconds");
						EditorGUILayout.EndHorizontal ();
						EditorGUILayout.BeginHorizontal ();
						EditorGUILayout.PrefixLabel (new GUIContent ("Maximum Time Between Spawns", "Maximum Seconds Delay For Each Spawn"));
						S.randomTimeBetweenSpawnsMax = EditorGUILayout.FloatField (S.randomTimeBetweenSpawnsMax);
						EditorGUILayout.LabelField (" Seconds");
						EditorGUILayout.EndHorizontal ();

					}
					GUILayout.Label ("");
				}

			}
			
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
			
		

			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Spawn Delays", "Delay Spawns By Time In Seconds Or By Passing An X, Y, Or Z Location"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			

		
			if (!S.WaveSpawning) {
				GUILayout.Label ("");
				S.startSpawnAfterTime = EditorGUILayout.Toggle (new GUIContent ("Spawn After Time", "Spawn The First Time After A Designated Amount of Time"), S.startSpawnAfterTime);
				if (S.startSpawnAfterTime) {
					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Start Spawn After", "Start Spawn After This Many Seconds"));
					S.singleSpawnTime = EditorGUILayout.FloatField (S.singleSpawnTime);
					EditorGUILayout.LabelField (" Seconds");
					EditorGUILayout.EndHorizontal ();
	
				}
			}
			if (!S.startSpawnAfterTime)
				S.singleSpawnTime = 0;
			GUILayout.Label ("");
			S.showSpawnAfter = EditorGUILayout.Toggle (new GUIContent ("Spawn After Location", "Start Spawn After Player Location Is Less/Greater Than Specified X, Y, Or Z"), S.showSpawnAfter);
			EditorGUI.indentLevel++;
			if (!S.showSpawnAfter) {
				S.AfterX = true;
				S.AfterY = true;
				S.AfterZ = true;
				S.After = true;
				S.startAtSpecificX = false;
				S.startAtSpecificY = false;
				S.startAtSpecificZ = false;
			}
			if (S.showSpawnAfter) {


				GUILayout.Label ("");
				S.startAtSpecificX = EditorGUILayout.Toggle ("Start Spawn After X Is:", S.startAtSpecificX);
				if (S.startAtSpecificX) {	
			
					EditorGUILayout.BeginHorizontal ();
					S.lessThanX = EditorGUILayout.Toggle ("Less Than", S.lessThanX);
					if (S.lessThanX) {
						S.moreThanX = false;
					}
					S.moreThanX = EditorGUILayout.Toggle ("More Than", S.moreThanX);
					if (S.moreThanX) {
						S.lessThanX = false;
					}
					EditorGUILayout.EndHorizontal ();
					EditorGUI.BeginDisabledGroup ((!S.lessThanX) && (!S.moreThanX));
					S.XStartSpawn = EditorGUILayout.FloatField (S.XStartSpawn);
					EditorGUI.EndDisabledGroup ();
				}

				GUILayout.Label ("");



				S.startAtSpecificY = EditorGUILayout.Toggle ("Start Spawn After Y Is:", S.startAtSpecificY);
				if (S.startAtSpecificY) {

					EditorGUILayout.BeginHorizontal ();
					S.lessThanY = EditorGUILayout.Toggle ("Less Than", S.lessThanY);
					if (S.lessThanY) {
						S.moreThanY = false;
					}
					S.moreThanY = EditorGUILayout.Toggle ("More Than", S.moreThanY);
					if (S.moreThanY) {
						S.lessThanY = false;
					}
					EditorGUILayout.EndHorizontal ();
					EditorGUI.BeginDisabledGroup ((!S.lessThanY) && (!S.moreThanY));

					S.YStartSpawn = EditorGUILayout.FloatField (S.YStartSpawn);
			
					EditorGUI.EndDisabledGroup ();


				}
				GUILayout.Label ("");

				S.startAtSpecificZ = EditorGUILayout.Toggle ("Start Spawn After Z Is:", S.startAtSpecificZ);
				if (S.startAtSpecificZ) {

					EditorGUILayout.BeginHorizontal ();
					S.lessThanZ = EditorGUILayout.Toggle ("Less Than", S.lessThanZ);
					if (S.lessThanZ) {
						S.moreThanZ = false;
					}
					S.moreThanZ = EditorGUILayout.Toggle ("More Than", S.moreThanZ);
					if (S.moreThanZ) {
						S.lessThanZ = false;
					}
					EditorGUILayout.EndHorizontal ();
					EditorGUI.BeginDisabledGroup ((!S.lessThanZ) && (!S.moreThanZ));
					S.ZStartSpawn = EditorGUILayout.FloatField (S.ZStartSpawn);
					EditorGUI.EndDisabledGroup ();

				}
			}
			EditorGUI.indentLevel--;

			if (!S.singleSpawn) {
				GUILayout.Label ("");
				GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
		
				GUILayout.BeginHorizontal ();
				GUILayout.FlexibleSpace ();
				GUILayout.Label (new GUIContent ("Wave Spawning", "Wave Spawning Section"), (EditorStyles.boldLabel));
				GUILayout.FlexibleSpace ();
				GUILayout.EndHorizontal ();
				GUILayout.Label ("");
			
			

				S.WaveSpawning = EditorGUILayout.Toggle ("Spawn In Waves", S.WaveSpawning);
			}

			if (S.WaveSpawning) {
					
				Rect r = EditorGUILayout.BeginVertical ();
				EditorGUI.ProgressBar (r, S.exactWave / S.numberOfWaves, S.WaveStatus);
				GUILayout.Space (16);
				EditorGUILayout.EndVertical ();
				GUILayout.Label ("");

				EditorGUILayout.BeginHorizontal ();

				S.infiniteWaves = EditorGUILayout.Toggle (new GUIContent ("Infinite Waves", "Sets Number of Waves to Float.MaxValue"), S.infiniteWaves);

				EditorGUILayout.EndHorizontal ();
				GUILayout.Label ("");

				EditorGUI.BeginDisabledGroup (S.infiniteWaves);
				EditorGUILayout.BeginHorizontal ();
				EditorGUILayout.PrefixLabel (new GUIContent ("# Of Waves", "The Total Number Of Waves You Want To Spawn"));

				S.numberOfWaves = EditorGUILayout.FloatField (S.numberOfWaves);
				GUILayout.Label ("          ");
				EditorGUILayout.EndHorizontal ();
				EditorGUI.EndDisabledGroup ();

				if (S.infiniteWaves) {
					S.numberOfWaves = float.MaxValue;
				}
				if (!S.infiniteWaves && S.numberOfWaves == float.MaxValue) {
					S.numberOfWaves = 1;
				}


				GUILayout.Label ("");
				EditorGUILayout.BeginHorizontal ();
				EditorGUILayout.PrefixLabel (new GUIContent ("# In Current Wave", "Number Of Objects In The Current Wave + Increment Amount"));
				S.numberOfObjectsInWave = EditorGUILayout.FloatField (S.numberOfObjectsInWave);
				GUILayout.Label ("          ");
				EditorGUILayout.EndHorizontal ();

				GUILayout.Label ("");
			

				EditorGUILayout.BeginHorizontal ();
				EditorGUILayout.PrefixLabel (new GUIContent ("Time Before Wave 1", "Time Before The First Wave Spawn"));
				S.delayOnFirstWave = EditorGUILayout.FloatField (S.delayOnFirstWave);
				EditorGUILayout.LabelField (" Seconds");
				EditorGUILayout.EndHorizontal ();
				GUILayout.Label ("");
				S.RandomspawnBetweenWavesTime = EditorGUILayout.Toggle (new GUIContent ("Random Time Between Waves", "A Random Time Between Each Wave Spawn"), S.RandomspawnBetweenWavesTime);
				GUILayout.Label ("");
			

				if (S.RandomspawnBetweenWavesTime) {
					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Minimum Time Between Waves", "Minimum Seconds Delay For Each Wave"));
					S.randomTimeBetweenWavesMin = EditorGUILayout.FloatField (S.randomTimeBetweenWavesMin);
					EditorGUILayout.LabelField (" Seconds");
					EditorGUILayout.EndHorizontal ();
					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Maximum Time Between Waves", "Maximum Seconds Delay For Each Wave"));
					S.randomTimeBetweenWavesMax = EditorGUILayout.FloatField (S.randomTimeBetweenWavesMax);
					EditorGUILayout.LabelField (" Seconds");
					EditorGUILayout.EndHorizontal ();
				}
				if (!S.RandomspawnBetweenWavesTime) {
					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Time Between Waves", "Time Between Each Wave In Seconds"));
					S.timeBetweenWaves = EditorGUILayout.FloatField (S.timeBetweenWaves);
					EditorGUILayout.LabelField (" Seconds");
					EditorGUILayout.EndHorizontal ();

				}
				GUILayout.Label ("");
				S.randomIncrement = EditorGUILayout.Toggle (new GUIContent ("Random Increment", "Randomly Increment Number Of Objects To Add To Next Wave"), S.randomIncrement);
				GUILayout.Label ("");
				if (S.randomIncrement) {
					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Minimum Increment", "Minimum Number Of Objects To Add To Next Wave"));
					S.waveIncrementMin = EditorGUILayout.FloatField (S.waveIncrementMin);
					EditorGUILayout.LabelField (" Per Wave");
					EditorGUILayout.EndHorizontal ();

					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.PrefixLabel (new GUIContent ("Maximum Increment", "Maximum Number Of Objects To Add To Next Wave"));
					S.waveIncrementMax = EditorGUILayout.FloatField (S.waveIncrementMax);
					EditorGUILayout.LabelField (" Per Wave");
					EditorGUILayout.EndHorizontal ();		

				}
				if (!S.randomIncrement) {
					EditorGUILayout.BeginHorizontal ();

					EditorGUILayout.PrefixLabel (new GUIContent ("Increment ", "Number Of Objects To Add To Next Wave"));
					S.waveIncrement = EditorGUILayout.FloatField (S.waveIncrement);
					EditorGUILayout.LabelField (" Per Wave");
					EditorGUILayout.EndHorizontal ();
					GUILayout.Label ("");

				}

			}
			
		

		
			if (S.singleSpawn) {
				S.WaveSpawning = false;
			
				
			}
			GUILayout.Label ("");
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
		


			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Spawn Locations", "Spawn In Specific, Random or Locations Based Off Of The Player"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");

			GUILayout.BeginHorizontal ();
		
			S.relativeToPlayer = EditorGUILayout.Toggle (new GUIContent ("Relative To Player", "This Will Make All Spawns Relevant To Current Location Of Player Object On X, Y Or Z Axis"), S.relativeToPlayer);
			GUILayout.EndHorizontal ();


			if (S.relativeToPlayer) {

				GUILayout.BeginHorizontal ();
				EditorGUI.indentLevel++;

				EditorGUILayout.PrefixLabel (new GUIContent ("X Axis", "This Will Make All Spawns Relevant To Current Location Of Player Object On The X Axis"));
				S.relativeToPlayerX = EditorGUILayout.Toggle ("", S.relativeToPlayerX);
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				EditorGUILayout.PrefixLabel (new GUIContent ("Y Axis", "This Will Make All Spawns Relevant To Current Location Of Player Object On The Y Axis"));
				S.relativeToPlayerY = EditorGUILayout.Toggle ("", S.relativeToPlayerY);
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				EditorGUILayout.PrefixLabel (new GUIContent ("Z Axis", "This Will Make All Spawns Relevant To Current Location Of Player Object On The Z Axis"));
				S.relativeToPlayerZ = EditorGUILayout.Toggle ("", S.relativeToPlayerZ);
				EditorGUI.indentLevel--;

				GUILayout.EndHorizontal ();
			}
			GUILayout.Label ("");

			S.SpawnRandomly = EditorGUILayout.Toggle (new GUIContent ("Spawn Randomly", "Spawn Object In Random Location Specified Below In Min And Max Spawn"), S.SpawnRandomly);

			if (S.SpawnRandomly) {
				S.SpawnRandomly = true;
				S.notZ = EditorGUILayout.Toggle (new GUIContent ("Z Does Not Change From 0", "Turns The Vector3 Into A Vector2"), S.notZ);



				if (!S.notZ) {
					GUILayout.Label ("");
					S.spawnMinLocation3 = EditorGUILayout.Vector3Field (new GUIContent ("Min Spawn", "Minimum Random Spawn Location Of Object"), S.spawnMinLocation3);
					S.spawnMaxLocation3 = EditorGUILayout.Vector3Field (new GUIContent ("Max Spawn", "Maximum Random Spawn Location Of Object"), S.spawnMaxLocation3);
				}
				if (S.notZ) {
					GUILayout.Label ("");
					S.spawnMinLocation2 = EditorGUILayout.Vector2Field (new GUIContent ("Min Spawn", "Minimum Random Spawn Location Of Object"), S.spawnMinLocation2);
					S.spawnMaxLocation2 = EditorGUILayout.Vector2Field (new GUIContent ("Max Spawn", "Maximum Random Spawn Location Of Object"), S.spawnMaxLocation2);
				}
			}
			if (!S.SpawnRandomly) {
				GUILayout.Label ("");
				S.specificSpawnPoint = EditorGUILayout.Vector3Field ("Specific Spawn Point", S.specificSpawnPoint);

			}
			GUILayout.Label ("");
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Spawn Rotations", "Spawn With Specific Or Random Rotations"), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			S.spawnRotation = EditorGUILayout.Toggle (new GUIContent ("Custom Rotation", "Spawn With A Custom Rotation Other Than 0"), S.spawnRotation);
		
			GUILayout.Label ("");
			EditorGUI.BeginDisabledGroup (!S.spawnRotation);
			S.randomRotation = EditorGUILayout.Toggle (new GUIContent ("Random Rotation", "Random Rotation To Spawn Objects At Between A Minimum And A Maximum"), S.randomRotation);
			EditorGUI.EndDisabledGroup ();
			if (S.spawnRotation) {
				if (!S.randomRotation) {
					GUILayout.Label ("");
					S.rotation = EditorGUILayout.Vector3Field (new GUIContent ("Spawn Rotation", "Specific Spawn Rotation For Objects To Spawn At"), S.rotation);
				}

				if (S.randomRotation) {
					GUILayout.Label ("");
					S.rotationRandomMin = EditorGUILayout.Vector3Field (new GUIContent ("Min Rotation", "Minumum Rotation That Objects Will Spawn With"), S.rotationRandomMin);
					S.rotationRandomMax = EditorGUILayout.Vector3Field (new GUIContent ("Max Rotation", "Maximum Rotation That Objects Will Spawn With"), S.rotationRandomMax);
				}
			}
			if (!S.spawnRotation && S.randomRotation)
				S.randomRotation = false;
			GUILayout.Label ("");
			GUILayout.Box ("", new GUILayoutOption[]{ GUILayout.ExpandWidth (true), GUILayout.Height (1) });
	

			if (!S.spawnRotation) {
				S.rotation = new Vector3 (0, 0, 0);
			
			}
			if (S.spawnRotation && S.randomRotation) {
				S.rotation = new Vector3 ((Random.Range (S.rotationRandomMin.x, S.rotationRandomMax.x)), (Random.Range (S.rotationRandomMin.y, S.rotationRandomMax.y)), (Random.Range (S.rotationRandomMin.z, S.rotationRandomMax.z)));
			}

			if (S.randomRotation && !S.spawnRotation) {
				S.spawnRotation = true;
			}

		
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (new GUIContent ("Debug Mode", ""), (EditorStyles.boldLabel));
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.Label ("");
			S.debugMode = EditorGUILayout.Toggle (new GUIContent ("Debug", "Shows Which Conditions Are Called During Spawn As Well As A Number To Reference In The Code."), S.debugMode);
			GUILayout.Label ("");
		}
			

	}

}
