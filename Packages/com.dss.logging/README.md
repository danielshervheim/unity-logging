# Logging

## How To Install

The caching package uses the [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) feature to import
dependent packages. Please add the following sections to the package manifest
file (`Packages/manifest.json`).

To the `scopedRegistries` section:

```
{
    "name": "DSS",
    "url": "https://registry.npmjs.com",
    "scopes": [ "com.dss" ]
}
```

To the `dependencies` section:

```
"com.unity.textmeshpro": "3.0.6",
"com.dss.core-utils": "1.6.4",
"com.dss.logging": "1.0.1"
```

After changes, the manifest file should look like below:

```
{
    "scopedRegistries": [
    {
        "name": "DSS",
        "url": "https://registry.npmjs.com",
        "scopes": [ "com.dss" ]
    }
    ],
    "dependencies": {
        "com.unity.textmeshpro": "3.0.6",
        "com.dss.core-utils": "1.6.4",
        "com.dss.logging": "1.0.1"
        ...
```

## Usage

Drag the `Logger` prefab into the scene, and then call it from scripts like so:

```csharp

// Reference the instance and make sure its enabled, so the messages appear on the screen
DSS.Logging.Logger logger = DSS.Logging.Logger.Instance;
logger.enabled = true;

// Then log like normal
logger.Log("This is a message");
logger.LogWarning("Look out!");
logger.LogError("Uh oh....");
````