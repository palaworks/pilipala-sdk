[<AutoOpen>]
module pilipala.util.text.time

open System

type DateTime with
    member self.ToIso8601() = self.ToString("o")
