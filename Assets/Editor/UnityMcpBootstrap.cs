using MCPForUnity.Editor.Services;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
internal static class UnityMcpBootstrap
{
    private const string ConfiguredKey = "FinalProject.UnityMcpBootstrap.Configured";

    static UnityMcpBootstrap()
    {
        EditorPrefs.SetBool("MCPForUnity.UseHttpTransport", true);
        EditorPrefs.SetString("MCPForUnity.HttpTransportScope", "local");
        EditorPrefs.SetString("MCPForUnity.HttpUrl", "http://127.0.0.1:8080");
        EditorPrefs.SetBool("MCPForUnity.AutoStartOnLoad", true);
        EditorPrefs.SetBool("MCPForUnity.SetupCompleted", true);
        EditorPrefs.SetBool("MCPForUnity.TelemetryDisabled", true);

        if (!SessionState.GetBool(ConfiguredKey, false))
        {
            SessionState.SetBool(ConfiguredKey, true);
            EditorApplication.delayCall += Connect;
        }
    }

    private static async void Connect()
    {
        try
        {
            bool connected = await MCPServiceLocator.Bridge.StartAsync();
            Debug.Log($"[Unity MCP Bootstrap] Connection result: {connected}");
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"[Unity MCP Bootstrap] Connection failed: {exception.Message}");
        }
    }
}
