using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMega : MonoBehaviour
{
	//player object
	public GameObject player;

	//objects to store your gameobjects
	public GameObject ObSingle;
	public GameObject ObSingle1;
	public GameObject ObSingle2;
	public GameObject ObSingle3;
	public GameObject ObSingle4;
	public GameObject ObSingle5;
	public GameObject ObSingle6;
	public GameObject ObSingle7;
	public GameObject ObSingle8;
	public GameObject ObSingle9;
	public GameObject ObSingle10;
	public GameObject[] Ob;

	//cooldown times
	public float timeBetweenWaves;
	public float randomTimeBetweenWavesMin;
	public float randomTimeBetweenWavesMax;
	public float delayOnFirstWave;
	public float timeBetweenSpawns;
	public float randomTimeBetweenSpawnsMin;
	public float randomTimeBetweenSpawnsMax;
	public float singleSpawnTime;

	//waveSpawning numbers
	public float numberOfWaves;
	public float numberOfObjectsInWave;
	public float waveIncrement;
	public float waveIncrementMin;
	public float waveIncrementMax;
	public float currentWave = 1;
	public float exactWave = 0;

	//values of player transform at x,y,z
	public float playerTrans;
	public float playerTransY;
	public float playerTransZ;

	//the value that must be hit if spawn after location is on for x,y,z
	public float XStartSpawn;
	public float YStartSpawn;
	public float ZStartSpawn;

	//total number of objects
	public int numberOfObjects;

	public int rand;

	//if wave spawn has random increments for each wave
	public bool randomIncrement;

	//the main spawn boolean if this is off nothing will spawn
	public bool Spawn;

	//used by current spawn object to make it read only
	public bool readOnly = true;

	//used to wait for spawning until player is alive
	public bool waitForDead;
	//This one is used for custom inspector check box
	public static bool isDead = false;

	//if we want to spawn randomly or from a specific point
	public bool SpawnRandomly;
	public bool SpawnFromPoint;

	//we use this if we want to spawn random between times
	public bool RandomspawnBetweenWavesTime;
	public bool RandomspawnBetweenTime;

	//we use this if we want to wave spawn objects
	public bool WaveSpawning;

	//used if there is no change to Z axis for spawn
	public bool notZ;

	//the generic waitToSpawn to work with cooldowns and time between spawns
	public bool waitToSpawn;
	//if we want to spawn a single object
	public bool singleSpawn;

	//if we are spawning using rotations we will use these
	public bool spawnRotation;
	public bool randomRotation;

	//bools for start spawn after a specific location x,y,z
	public bool showSpawnAfter;
	public bool startAtSpecificX;
	public bool startAtSpecificY;
	public bool startAtSpecificZ;

	//if less than a specific x,y,z start spawn uses these bools
	public bool lessThanX;
	public bool moreThanX;
	public bool lessThanY;
	public bool moreThanY;
	public bool lessThanZ;
	public bool moreThanZ;
	public bool After = true;
	public bool AfterX = true;
	public bool AfterY = true;
	public bool AfterZ = true;

	//start spawn time delays
	public bool startSpawnAfterTime;
	public bool spawnAfterTime = true;
	public bool delayBetweenWaves;

	//relatve to player
	public bool relativeToPlayer;
	public bool relativeToPlayerX;
	public bool relativeToPlayerY;
	public bool relativeToPlayerZ;

	//if we want infinite waves in wave spawning we use this to set # of waves to float.maxvalue
	public bool infiniteWaves;

	//we use debugmode if you want to see a number correlating with order of instantiates within code and the conditions that are being met to call that specific spawn
	public bool debugMode;

	//values to store our min/max locations and spawn points
	public Vector2 spawnMinLocation2;
	public Vector2 spawnMaxLocation2;
	public Vector3 spawnMinLocation3;
	public Vector3 spawnMaxLocation3;
	public Vector3 specificSpawnPoint;

	//rotation values
	public Vector3 rotation;
	public Vector3 rotationRandomMin;
	public Vector3 rotationRandomMax;

	public string WaveStatus;

	// Use this for initialization
	void Start ()
	{
		
		//	ObSingle = GameObject.FindWithTag("spawnObject");
		if (startAtSpecificX || startAtSpecificY || startAtSpecificZ) {
			After = false;
			AfterX = false;
			AfterY = false;
			AfterZ = false;
			
		}
		if (startSpawnAfterTime)
			spawnAfterTime = false;
		


		if (singleSpawn || singleSpawnTime != 0) {
			waitToSpawn = true;
			StartCoroutine (singleSpawnDelay ());
		}

		if (startAtSpecificX && !lessThanX && !moreThanX)
			startAtSpecificX = false;
		if (startAtSpecificY && !lessThanY && !moreThanY)
			startAtSpecificY = false;
		if (startAtSpecificZ && !lessThanZ && !moreThanZ)
			startAtSpecificZ = false;

		if (AfterX && AfterY && AfterZ && spawnAfterTime) {
			After = true;
		}
		if (!startAtSpecificX)
			AfterX = true;
		if (!startAtSpecificY)
			AfterY = true;
		if (!startAtSpecificZ)
			AfterZ = true;
		if (!startSpawnAfterTime)
			spawnAfterTime = true;
		if (delayOnFirstWave > 0 && WaveSpawning) {
			waitToSpawn = true;
			singleSpawnTime = 0;
			StartCoroutine (initialWaveDelay ());
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

		//Make sure all time conditions have been met.
		if (startSpawnAfterTime && !spawnAfterTime && Time.time > singleSpawnTime)
			spawnAfterTime = true;

		//Make sure all location conditions have been met and if so change status to true
		if (startAtSpecificX && lessThanX && player.transform.position.x < XStartSpawn)
			AfterX = true;
		if (startAtSpecificX && moreThanX && player.transform.position.x > XStartSpawn)
			AfterX = true;
		if (startAtSpecificY && lessThanY && player.transform.position.y < YStartSpawn)
			AfterY = true;
		if (startAtSpecificY && moreThanY && player.transform.position.y > YStartSpawn)
			AfterY = true;
		if (startAtSpecificZ && lessThanZ && player.transform.position.z < ZStartSpawn)
			AfterZ = true;
		if (startAtSpecificZ && moreThanZ && player.transform.position.z > ZStartSpawn)
			AfterZ = true;
		if (!After) {
			if (AfterX && AfterY && AfterZ && spawnAfterTime) {
				After = true;
			}
		}
	
		//All spawns happen in this spawn if statement
		if (Spawn && ((!waitForDead) || (!isDead && waitForDead))) {
			//if not relative to player change bool status and default spawn to 0.
			if (!relativeToPlayer) {
				playerTrans = 0;
				playerTransY = 0;
				playerTransZ = 0;
				relativeToPlayerX = false;
				relativeToPlayerY = false;
				relativeToPlayerZ = false;
			}
			//if relative to the player we set the x/y/z to the player's x/y/z
			if (relativeToPlayer) {
				if (relativeToPlayerX)
					playerTrans = player.transform.position.x;
				if (relativeToPlayerY)
					playerTransY = player.transform.position.y;
				if (relativeToPlayerZ)
					playerTransZ = player.transform.position.z;
			}

			//if not single spawn, not wave spawning, not spawning randomly, after spawn location, 
			if (!singleSpawn && !WaveSpawning && !SpawnRandomly && After) {
				
				if (!waitToSpawn) {
					Randomize ();
					if (debugMode)
						Debug.Log ("1st Instantiate, Conditions Being Met: not spawnrandomly, not single spawn, not wave spawning, after, and not waittospawn");	
					Instantiate (ObSingle, new Vector3 ((specificSpawnPoint.x + playerTrans), specificSpawnPoint.y + playerTransY, specificSpawnPoint.z + playerTransZ), Quaternion.Euler (rotation));

				}
				waitToSpawn = true;
				StartCoroutine (resetSpawn ());
			}

			//if not spawnrandomly, not single spawn,  wave spawning, after, and not waittospawn, current waves <= numWaves"
			if (WaveSpawning && !singleSpawn && !SpawnRandomly && After && currentWave <= numberOfWaves && !waitToSpawn) {

				//for (int i = 1; i <= numberOfObjectsInWave + waveIncrement; i++) {
				int i = 0;
				while (i < numberOfObjectsInWave) {
					Randomize ();
					if (debugMode)
						Debug.Log ("2nd Instantiate, Conditions Being Met: not spawnrandomly, not single spawn,  wave spawning, after, and not waittospawn, current waves <= numWaves");
					Instantiate (ObSingle, new Vector3 ((specificSpawnPoint.x + playerTrans), specificSpawnPoint.y + playerTransY, specificSpawnPoint.z + playerTransZ), Quaternion.Euler (rotation));
					i++;
				}
				//if not random spawn based off regular waveIncrement
				if (!randomIncrement)
					numberOfObjectsInWave += waveIncrement;
				//if random spawn based 2 random numbers waveIncrementMin and waveIncrementMax
				if (randomIncrement)
					numberOfObjectsInWave += Mathf.Round (Random.Range (waveIncrementMin, waveIncrementMax));
				waitToSpawn = true;
				currentWave++;
				exactWave++;
				WaveStatus = "Wave " + exactWave + "/" + numberOfWaves;
				StartCoroutine (resetSpawnWaves ());
						
			}//End WaveSpawning
			//not single spawn, wavespawning, spawnrandomly, after, currentwave<=numwaves, not waittospawn, not not z"
			if (!singleSpawn && WaveSpawning && SpawnRandomly && After && currentWave <= numberOfWaves) {
				int i = 0;
				if (!waitToSpawn) {
					while (i < numberOfObjectsInWave) {
						if (!notZ) {
							Randomize ();
							if (debugMode)
								Debug.Log ("3rd Instantiate, Conditions Being Met:  not single spawn, wavespawning, spawnrandomly, after, currentwave<=numwaves, not waittospawn, not not z");
							Instantiate (ObSingle, new Vector3 (Random.Range (spawnMinLocation3.x, spawnMaxLocation3.x) + playerTrans, Random.Range (spawnMinLocation3.y, spawnMaxLocation3.y) + playerTransY, Random.Range (spawnMinLocation3.z, spawnMaxLocation3.z) + playerTransZ), Quaternion.Euler (rotation));
									
						}
						//if we are using a vector 2 or when there are no changes on Z.
						if (notZ) {
							Randomize ();
							if (debugMode)
								Debug.Log ("4th Instantiate, Conditions Being Met:  not single spawn, wavespawning, spawnrandomly, after, currentwave<=numwaves, not waittospawn, not z");

							Instantiate (ObSingle, new Vector2 (Random.Range (spawnMinLocation2.x, spawnMaxLocation2.x) + playerTrans, Random.Range (spawnMinLocation2.y, spawnMaxLocation2.y) + playerTransY), Quaternion.Euler (rotation));
						}
						i++;
					}
					//if not random spawn based off regular waveIncrement
					if (!randomIncrement)
						numberOfObjectsInWave += waveIncrement;
					//if random spawn based 2 random numbers waveIncrementMin and waveIncrementMax
					if (randomIncrement)
						numberOfObjectsInWave += Mathf.Round (Random.Range (waveIncrementMin, waveIncrementMax));
					waitToSpawn = true;
					currentWave++;
					exactWave++;
					WaveStatus = "Wave " + exactWave + "/" + numberOfWaves;
					StartCoroutine (resetSpawnWaves ());  
				}
			}


			//if singlespawn, after, not spawnrandomly, and not waittospawn
			if (singleSpawn) {
				if (After) {
					if (!SpawnRandomly) {
					
						if (!waitToSpawn) {
							
							Randomize ();
							if (debugMode)
								Debug.Log ("5th Instantiate, Conditions Being Met: single spawn, after, not spawn randomly, not waittospawn");
							Instantiate (ObSingle, new Vector3 ((specificSpawnPoint.x + playerTrans), specificSpawnPoint.y + playerTransY, specificSpawnPoint.z + playerTransZ), Quaternion.Euler (rotation));
							waitToSpawn = true;
						}
					}
				
					//if spawnrandomly and not waittospawn with possible change on Z
					if (SpawnRandomly && !waitToSpawn) {
						if (!notZ) {
							Randomize ();
							if (debugMode)
								Debug.Log ("6th Instantiate, Conditions Being Met: singlespawn, after, spawn randomly, waittospawn ");
							Instantiate (ObSingle, new Vector3 (Random.Range (spawnMinLocation3.x, spawnMaxLocation3.x) + playerTrans, Random.Range (spawnMinLocation3.y, spawnMaxLocation3.y) + playerTransY, Random.Range (spawnMinLocation3.z, spawnMaxLocation3.z) + playerTransZ), Quaternion.Euler (rotation));
							waitToSpawn = true;
						}
						//if spawnrandomly and not waittospawn and no change on Z 
						if (notZ) {
							Randomize ();
							if (debugMode)
								Debug.Log ("7th Instantiate, Conditions Being Met: singlespawn, after, spawn randomly, waittospawn and not Z");
							Instantiate (ObSingle, new Vector2 (Random.Range (spawnMinLocation2.x, spawnMaxLocation2.x) + playerTrans, Random.Range (spawnMinLocation2.y, spawnMaxLocation2.y) + playerTransY), Quaternion.Euler (rotation));
							waitToSpawn = true;
						}
						waitToSpawn = true;
						
					}
				}
			}
			//if we are not on singlespawn and not using wave spawning, and using spawnrandomly and after location
			if (SpawnRandomly && !singleSpawn && !WaveSpawning && After && !waitToSpawn) {
					
				if (!notZ) {
					Randomize ();
					if (debugMode)
						Debug.Log ("8th Instantiate, Conditions Being Met: spawnrandomly, not single spawn, not wave spawning, after, and not waittospawn");
					Instantiate (ObSingle, new Vector3 (Random.Range (spawnMinLocation3.x, spawnMaxLocation3.x) + playerTrans, Random.Range (spawnMinLocation3.y, spawnMaxLocation3.y) + playerTransY, Random.Range (spawnMinLocation3.z, spawnMaxLocation3.z) + playerTransZ), Quaternion.Euler (rotation));
				}
				if (notZ) {
					Randomize ();
					if (debugMode)
						Debug.Log ("9th Instantiate, Conditions Being Met: spawnrandomly, not single spawn, not wave spawning, after, and not waittospawn, not Z");
					Instantiate (ObSingle, new Vector2 (Random.Range (spawnMinLocation2.x, spawnMaxLocation2.x) + playerTrans, Random.Range (spawnMinLocation2.y, spawnMaxLocation2.y) + playerTransY), Quaternion.Euler (rotation));
				}
				waitToSpawn = true;
				StartCoroutine (resetSpawn ());
				


			
			}
		}
	}
	//used to change value of waittospawn if we are using wave spawning.
	IEnumerator resetSpawnWaves ()
	{
		yield return new WaitForSeconds (timeBetweenWaves);
		waitToSpawn = false;
		//	StopCoroutine (resetSpawn ());

		StopAllCoroutines ();

	}
	//used to change the value of waittospawn if we are using a regular spawn with a normal time between each spawn
	IEnumerator resetSpawn ()
	{
		yield return new WaitForSeconds (timeBetweenSpawns);
		waitToSpawn = false;
		//	StopCoroutine (resetSpawn ());
		StopAllCoroutines ();

	}
	//used to change the value of waittospawn assuming we want the first wave delayed
	IEnumerator initialWaveDelay ()
	{
		yield return new WaitForSeconds (delayOnFirstWave);
		waitToSpawn = false;
		//	StopCoroutine (resetSpawn ());
		StopAllCoroutines ();

	}
	//used to change the value of waittospawn if we have selected to use singlespawn
	IEnumerator singleSpawnDelay ()
	{
		yield return new WaitForSeconds (singleSpawnTime);
		waitToSpawn = false;
		//	StopCoroutine (resetSpawn ());
		StopAllCoroutines ();

	}

	//each time this is called our ObjectSingle is set equal to a random object that we have added from ObSingle1-Obsingle10
	void Randomize ()
	{
		//We randomly pick a number for delay between spawns/waves if chosen to spawn with random time
		if (RandomspawnBetweenTime)
			timeBetweenSpawns = Random.Range (randomTimeBetweenSpawnsMin, randomTimeBetweenSpawnsMax);
		if (RandomspawnBetweenWavesTime)
			timeBetweenWaves = Random.Range (randomTimeBetweenWavesMin, randomTimeBetweenWavesMax);
		
		rand = Random.Range (0, numberOfObjects);
		if (numberOfObjects != 0) {
			if (rand == 0)
				ObSingle = ObSingle1;
			if (rand == 1)
				ObSingle = ObSingle2;
			if (rand == 2)
				ObSingle = ObSingle3;
			if (rand == 3)
				ObSingle = ObSingle4;
			if (rand == 4)
				ObSingle = ObSingle5;
			if (rand == 5)
				ObSingle = ObSingle6;
			if (rand == 6)
				ObSingle = ObSingle7;
			if (rand == 7)
				ObSingle = ObSingle8;
			if (rand == 8)
				ObSingle = ObSingle9;
			if (rand == 9)
				ObSingle = ObSingle10;

		}




	}

}

