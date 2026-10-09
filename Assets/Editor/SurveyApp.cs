using UnityEditor;

// The Survey app: measures a room's AprilTags (the first one seen defines the
// room) and saves room_config.json and the room code (QR) for the other apps.
// Menu: Tools > Survey. Batchmode (re-runnable; Build also configures):
//   -buildTarget iOS -executeMethod SurveyApp.BuildIOS        (Xcode project in Builds/iOS)
//   -buildTarget Android -executeMethod SurveyApp.BuildQuest  (Builds/Quest/Survey.apk)
public static class SurveyApp
{
    public static readonly AprilTagsAppInfo App = new()
    {
        ProductName = "Survey",
        BundleId = "edu.utexas.tacc.survey",
        AppleTeamId = "MQSWMVW9A8",
        LogFileName = "survey.log",
        IPhoneScenes = new[] { "Assets/Scenes/iPhone Survey.unity" },
        QuestScenes = new[] { "Assets/Scenes/Quest Survey.unity" },
    };

    [MenuItem("Tools/Survey/Configure iOS")]
    public static void ConfigureIOS() => AprilTagsIOSSetup.Configure(App);

    [MenuItem("Tools/Survey/Build iOS Xcode Project")]
    public static void BuildIOS()
    {
        ConfigureIOS();
        AprilTagsIOSSetup.Build(App);
    }

    [MenuItem("Tools/Survey/Configure Quest")]
    public static void ConfigureQuest() => AprilTagsQuestSetup.Configure(App);

    [MenuItem("Tools/Survey/Build Quest APK")]
    public static void BuildQuest()
    {
        ConfigureQuest();
        AprilTagsQuestSetup.Build(App);
    }
}
