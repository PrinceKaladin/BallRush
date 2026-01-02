using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/menu.unity",
        "Assets/Scenes/gameplay.unity",
        "Assets/Scenes/rules.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "BallRush.aab";
        string apkPath = "BallRush.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64 ="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";
        string keystorePass = "ballll";
        string keyAlias = "ballll";
        string keyPass = "ballll";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

    PlayerSettings.Android.useCustomKeystore = true;
    PlayerSettings.Android.keystoreName = tempKeystorePath;
    PlayerSettings.Android.keystorePass = keystorePass;
    PlayerSettings.Android.keyaliasName = keyAlias;
    PlayerSettings.Android.keyaliasPass = keyPass;

    Debug.Log("Android signing configured from Base64 keystore.");
}
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. Сборка APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}