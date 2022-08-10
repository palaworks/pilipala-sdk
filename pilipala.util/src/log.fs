[<AutoOpen>]
module pilipala.util.log

open fsharper.typ
open Microsoft.Extensions.Logging

type ILogger<'t> with

    member inline self.trace msg = effect self.LogTrace msg
    member inline self.debug msg = effect self.LogDebug msg
    member inline self.info msg = effect self.LogInformation msg
    member inline self.warning msg = effect self.LogWarning msg
    member inline self.error msg = effect self.LogError msg
    member inline self.critical msg = effect self.LogCritical msg

type ILogger<'t> with
    member inline self.alwaysPrepend msg =
        { new ILogger<'t> with
            member i.Log<'a>(lv, eid, stat, exn, fmt) =
                (self :> ILogger)
                    .Log<'a>(lv, eid, stat, exn, (fun s e -> $"{msg}{fmt.Invoke(s, e)}"))

            member i.IsEnabled x = (self :> ILogger).IsEnabled x

            member i.BeginScope<'a> x = (self :> ILogger).BeginScope<'a> x }

    member inline self.alwaysAppend msg =
        { new ILogger<'t> with
            member i.Log<'a>(lv, eid, stat, exn, fmt) =
                (self :> ILogger)
                    .Log<'a>(lv, eid, stat, exn, (fun s e -> $"{fmt.Invoke(s, e)}{msg}"))

            member i.IsEnabled x = (self :> ILogger).IsEnabled x

            member i.BeginScope<'a> x = (self :> ILogger).BeginScope<'a> x }
