[<AutoOpen>]
module pilipala.util.hash.md5

open System
open System.Security.Cryptography
open pilipala.util.encoding
open pilipala.util.text.fmt

type Md5 = { md5: string }

type String with

    /// 字符串的md5签名
    member self.md5 =
        { md5 = self |> utf8ToBytes |> MD5.Create().ComputeHash |> bytesToHex |> lowerCase }

type Md5 with

    member self.Verify(text: string) = text.md5.md5 = self.md5
