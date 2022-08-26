[<AutoOpen>]
module pilipala.util.text.html

open System
open System.Text.RegularExpressions

type Html = { html: string }

let inline private rm p i = Regex.Replace(i, p, "")
let inline private replace p i (r: string) = Regex.Replace(i, p, r)

type Html with
    /// 去除html标签
    member self.withoutTags() =
        match self.html with
        | null
        | "" -> ""
        | _ ->

            self.html
            |> rm "<script[^>]*>(.|\n)*?</script>" //脚本标签
            |> rm "<style>(.|\n)*</style>" //样式标签
            |> rm "<([^>]|\n)+>" //其他标签
            |> rm "^\s*\n" //空行去除（不考虑最后一行，后续逻辑会将其去除）
            |> replace "&#*\w+;" " " //将转义替换为空格
            |> replace "[\s\n]+" " " //多空白合并
            |> rm "^ | $" //首尾去空格

    /// 字数估计
    member self.wordCountEstimate() =
        match self.html with
        | null
        | "" -> 0
        | _ ->

            self.html
            |> rm "<script[^>]*>(.|\n)*?</script>" //脚本标签
            |> rm "<style>(.|\n)*</style>" //样式标签
            |> rm "<([^>]|\n)+>" //其他标签
            |> rm "[，,。.《》（(）)！!“”‘’？?/\s\n]" //空白和常用标点去除
            |> rm "&#*\w+;" //去除转义
            |> fun s -> s.Length
