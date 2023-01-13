[<AutoOpen>]
module pilipala.util.hash.sha1

open System
open System.Security.Cryptography
open pilipala.util.encoding

type Sha1 = { sha1: string }

type String with

    /// 字符串的sha1签名
    member self.sha1 =
        { sha1 =
            self
            |> utf8ToBytes
            |> SHA1.Create().ComputeHash
            |> bytesToHex }

type Sha1 with
    member self.Verify(text: string) = text.sha1.sha1 = self.sha1
