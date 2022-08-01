[<AutoOpen>]
module pilipala.util.hash.md5

open System
open System.Security.Cryptography
open pilipala.util.encoding

type String with

    /// 字符串的md5签名
    member self.md5 =
        self
        |> utf8ToBytes
        |> MD5.Create().ComputeHash
        |> bytesToHex
