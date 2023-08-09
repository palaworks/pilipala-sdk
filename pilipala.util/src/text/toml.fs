[<AutoOpen>]
module pilipala.util.text.toml

open System
open Tomlyn
open fsharper.typ

type Toml = { toml: string }

type Toml with
    /// 反序列化
    member self.deserializeTo<'t when 't: not struct and 't: (new: unit -> 't)>() =
        fun _ -> Toml.ToModel<'t> self.toml
        |> Result'.fromThrowable

    /// 序列化
    static member serializeFrom(obj) = { toml = Toml.FromModel obj }

type Object with
    /// 序列化到 TOML
    member self.serializeToToml() = Toml.serializeFrom self
