﻿[<AutoOpen>]
module pilipala.util.hash.sha512

open System
open System.Security.Cryptography
open pilipala.util.encoding

type SHA512 = { sha512: string }

type String with

    /// 字符串的sha512签名
    member self.sha512 =
        { sha512 =
            self
            |> utf8ToBytes
            |> SHA512.Create().ComputeHash
            |> bytesToHex }

type SHA512 with
    member self.Verify(text: string) = text.sha512.sha512 = self.sha512
