﻿[<AutoOpen>]
module pilipala.util.hash.bcrypt

open System
open BCrypt.Net

type BCrypt = { bcrypt: string }

type String with

    /// 字符串的bcrypt签名
    /// 使用随机salt
    member self.bcrypt =
        { bcrypt = BCrypt.HashPassword(self) }

type BCrypt with
    member self.Verify text =
        BCrypt.Net.BCrypt.Verify(text, self.bcrypt)
