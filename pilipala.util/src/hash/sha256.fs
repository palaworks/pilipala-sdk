﻿[<AutoOpen>]
module pilipala.util.hash.sha256

open System
open System.Security.Cryptography
open pilipala.util.encoding
open pilipala.util.text.fmt

type Sha256 = { sha256: string }

type String with

    /// 字符串的sha256签名
    member self.sha256 =
        { sha256 = self |> utf8ToBytes |> SHA256.Create().ComputeHash |> bytesToHex |> lowerCase }

type Sha256 with

    member self.Verify(text: string) = text.sha256.sha256 = self.sha256
