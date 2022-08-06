[<AutoOpen>]
module pilipala.util.hash.md5

open System
open System.Security.Cryptography
open pilipala.util.encoding

type MD5 = { md5: string }

type String with

    /// 字符串的md5签名
    member self.md5 =
        { md5 =
            self
            |> utf8ToBytes
            |> MD5.Create().ComputeHash
            |> bytesToHex }

type MD5 with
    member self.Verify(text: string) = text.md5.md5 = self.md5
