[<AutoOpen>]
module pilipala.util.text.fmt

open System
open System.Text.RegularExpressions
open fsharper.alias

let inline private rm p i = Regex.Replace(i, p, "")
let inline private replace p i (r: string) = Regex.Replace(i, p, r)

let inline upperCase s = (s: string).ToUpper()
let inline lowerCase s = (s: string).ToLower()

type String with
    //TODO

    /// 去除标点
    member self.removePunctuations() =
        //目前仅去除常用标点
        self |> rm "[，#,。.《》（(）)！!“”‘’？?/\s]"

    /// 去除换行
    member self.removeWraps() = self.Replace("\n", "")

    /// 合并空白
    member self.mergeBlanks() = Regex.Replace(self, "\s+", " ")

    /// 字数估计
    member self.estimateWords() =
        self.removePunctuations().removeWraps().Length

    member self.prefix(length: i32) =
        let max = self.Length

        if length > max then self else self.Substring(0, length)

    member self.postfix(length: i32) =
        let max = self.Length

        if length > max then
            self
        else
            self.Substring(max - length, length)
