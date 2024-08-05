# ABOUT THE PACKAGE

The main purpose of this package is to create a saving system that works well with WebGL builds, and won't get reset after publishing new game builds, since platforms like itch.io will reset data when the game's build is changed.

To get around this, we will use a JavaScript plugin to save to the browser's `localStorage` instead of the IndexedDB which is where Unity's PlayerPrefs or similar systems will save to.

Even though this was made for WebGL games, this should work the same with standalone builds as well, since it automatically detects it's environment and uses the correct saving method based on that.

    - localStorage on WebGL builds.
    - PlayerPrefs on all other builds.
 
# HOW TO SET UP:

1. Download the unitypackage file from the releases. 
2. Open your Unity Project
3. Drag and drop your downloaded unitypackage file.
4. The package should now be installed into your project.

# GETTING STARTED:

Create an empty gameobject and add the `LocalStorageManager` script to it.

Create or open any C# script in your project.

You do not need to define the Local Storage Manager, but it will be easier, you can just type this into your C# script:

` private LocalStorageManager storageManager; `

   - You can now add this code to the Start() function of your script:

     ` storageManager = LocalStorageManager.Instance; `


Now we are already prepared to use the system and save any data, here's all the functions you can use:

**SAVING VALUES:**

`SaveString(string key, string value)` - Saves a string value.

`SaveInt(string key, int value)` - Saves an integer value.

`SaveFloat(string key, float value)` - Saves a float value.


**LOADING VALUES:**

`LoadString(string key)` - Returns the string value.

`LoadInt(string key)` - Returns the integer value.

`LoadFloat(string key)` - Returns the float value.


**CHECKING VALUES:**

`HasKey(string key)` - Checks if a value with the key exists on the device. (returns a boolean value)


**DELETING VALUES:**

`Delete(string key)` - Clears the data stored with that key.

`DeleteAll()` - Clears all data.


# USAGE:

To use any of these functions, you can simply call the `storageManager` we set before.

*Example with storageManager:*

    if(storageManager.HasKey("score")) {
        Debug.Log("Last saved score is: " + storageManager.LoadInt("score"));
    }

   - The code above will check if a value with the key "score" exists, and if so, print it to the console.

If you don't want to set the storageManager variable, you can directly call to the Local Storage Manager instead.

*Example without storageManager:*

    if(LocalStorageManager.Instance.HasKey("score")) {
        Debug.Log("Last saved score is: " + LocalStorageManager.Instance.LoadInt("score"));
    }

  - The code above does the exact same thing as the last one, however without the storageManager reference being required.


## That's just about it, Thanks for reading!
