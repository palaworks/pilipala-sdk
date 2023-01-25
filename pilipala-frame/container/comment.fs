namespace pilipala.container.comment

open System
open System.Collections
open System.Collections.Generic
open fsharper.typ
open fsharper.alias

type CommentBinding =
    | BindPost of i64
    | BindComment of i64

/// 评论数据
/// 此类型仅面向底层公开，负责临时装载非映射数据
type CommentData =
    { Id: i64
      Body: string
      CreateTime: DateTime
      ModifyTime: DateTime
      Binding: CommentBinding
      UserId: i64
      Permission: u8
      Props: Map<string, obj> }

    member self.Item name =
        self.Props.TryGetValue(name).intoOption' ()

    interface IEnumerable<KeyValuePair<string, obj>> with
        member i.GetEnumerator() =
            (i.Props :> IEnumerable).GetEnumerator()

        member i.GetEnumerator() =
            (i.Props :> IEnumerable<_>).GetEnumerator()

/// 评论映射
/// 此类型面向底层公开，负责同步性更改数据库条目
type IMappedComment =
    abstract Id: i64
    abstract Body: string with get, set
    abstract CreateTime: DateTime with get, set
    abstract ModifyTime: DateTime with get, set
    abstract Binding: CommentBinding with get, set
    abstract UserId: i64 with get, set
    abstract Permission: u8 with get, set
    abstract Item: string -> Option'<obj> with get, set
//TODO 可以添加Item迭代器，以实现在Init管道的udf初始化

type IMappedCommentProvider =
    abstract fetch: i64 -> IMappedComment
    abstract create: CommentData -> IMappedComment
    abstract delete: i64 -> CommentData

type IComment =

    abstract CanRead: bool
    abstract CanWrite: bool
    abstract CanComment: bool

    abstract Id: i64
    abstract Body: Result'<string, string>
    abstract CreateTime: Result'<DateTime, string>
    abstract ModifyTime: Result'<DateTime, string>
    abstract Binding: Result'<CommentBinding, string>
    abstract UserId: Result'<i64, string>
    abstract Permission: Result'<u8, string>

    abstract Item: string -> Result'<Option'<obj>, string>
    abstract Comments: Result'<IComment seq, string>

    abstract UpdateBody: string -> Result'<unit, string>
    abstract UpdatePermission: u8 -> Result'<unit, string>
    abstract UpdateItem: string -> obj -> Result'<unit, string>

    abstract NewComment: string -> Result'<IComment, string>
    abstract Drop: unit -> Result'<CommentData, string>
