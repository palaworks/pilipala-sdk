[<AutoOpen>]
module pilipala.util.text.html

open System
open System.Text.RegularExpressions
open System.Web

type Html = { html: string }

let inline private rm p i = Regex.Replace(i, p, "")
let inline private replace p i (r: string) = Regex.Replace(i, p, r)

type Html with
    /// 去除html标签
    member self.removeTags() =
        match self.html with
        | null
        | "" -> ""
        | _ ->

            self.html
            |> rm "<script[^>]*>(.|\n)*?</script>" //脚本标签
            |> rm "<style>(.|\n)*</style>" //样式标签
            |> rm "<([^>]|\n)+>" //其他标签
            //|> rm "&#*\w+;" //去除转义
            |> HttpUtility.HtmlDecode
