namespace pilipala.plugin

open fsharper.alias

type IPluginCfgProvider =
    abstract config: string with get, set

type AppLifeCycle =
    | BeforeBuild = 0
    | AfterBuild = 1

type HookOnAttribute(time: AppLifeCycle) =
    inherit System.Attribute()
    member self.time = time
