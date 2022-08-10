using System;
using AvantiPoint.Nuke.Maui;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Tools.NerdbankGitVersioning;



class Build : MauiBuild
{
    public static int Main () => Execute<Build>();

    private static long Start => new DateTimeOffset(2022, 8, 10, 0, 0, 0, TimeSpan.Zero).ToUnixTimeSeconds();
    private static long Now => DateTimeOffset.Now.ToUnixTimeSeconds();
    private static long LocalBuildTimeStamp => (Now - Start) / 60;

    public GitHubActions GitHubActions => GitHubActions.Instance;

    [NerdbankGitVersioning]
    readonly NerdbankGitVersioning nerdbankVersioning;
    public override string ApplicationDisplayVersion => nerdbankVersioning.SimpleVersion;
    public override long ApplicationVersion => IsLocalBuild ? LocalBuildTimeStamp : GitHubActions.RunNumber;
}