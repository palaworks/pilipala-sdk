﻿[<AutoOpen>]
module pilipala.util.text.json

open System
open Newtonsoft.Json
open Newtonsoft.Json.Converters
open Newtonsoft.Json.Linq
open fsharper.op
open fsharper.typ

type Json = { json: string }

type Json with
    /// 反序列化
    member self.deserializeTo<'t>() =
        fun _ -> JsonConvert.DeserializeObject<'t> self.json
        |> Result'.fromThrowable

    /// 序列化
    static member serializeFrom(obj) =
        { json =
            (obj, IsoDateTimeConverter(DateTimeFormat = "yyyy-MM-dd HH:mm:ss"))
            |> JsonConvert.SerializeObject }

type Object with
    /// 序列化到 JSON
    member self.serializeToJson() = Json.serializeFrom self
