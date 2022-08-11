namespace pilipala.container.post

open System
open fsharper.alias
open fsharper.typ

/// 文章数据
/// 此类型仅面向底层公开，负责临时装载非映射数据
type PostData =
    { Id: i64
      Title: string
      Body: string
      CreateTime: DateTime
      AccessTime: DateTime
      ModifyTime: DateTime
      UserId: i64
      Permission: u8
      Item: string -> Option'<obj> }

/// 文章映射
/// 此类型仅面向底层公开，负责同步性更改数据库条目
type IMappedPost =
    abstract Id: i64
    abstract Title: string with get, set
    abstract Body: string with get, set
    abstract CreateTime: DateTime with get, set
    abstract AccessTime: DateTime with get, set
    abstract ModifyTime: DateTime with get, set
    abstract UserId: i64 with get, set
    abstract Permission: u8 with get, set
    abstract Item: string -> Option'<obj> with get, set

//TODO 可以添加Item迭代器，以实现在Init管道的udf初始化

type IMappedPostProvider =
    abstract fetch: i64 -> IMappedPost
    abstract create: PostData -> IMappedPost
    abstract delete: i64 -> PostData
