namespace pilipala.container.comment

open System
open fsharper.typ
open fsharper.alias

type CommentBinding =
    | BindPost of u64
    | BindComment of u64

/// 评论数据
/// 此类型仅面向底层公开，负责临时装载非映射数据
type CommentData =
    { Id: u64
      Body: string
      CreateTime: DateTime
      Binding: CommentBinding
      UserId: u64
      Permission: u8
      Item: string -> Option'<obj> }

/// 评论映射
/// 此类型面向底层公开，负责同步性更改数据库条目
type IMappedComment =
    abstract Id: u64
    abstract Body: string with get, set
    abstract CreateTime: DateTime with get, set
    abstract Binding: CommentBinding with get, set
    abstract UserId: u64 with get, set
    abstract Permission: u8 with get, set
    abstract Item: string -> Option'<obj> with get, set
//TODO 可以添加Item迭代器，以实现在Init管道的udf初始化

type IMappedCommentProvider =
    abstract fetch: u64 -> IMappedComment
    abstract create: CommentData -> IMappedComment
    abstract delete: u64 -> CommentData
