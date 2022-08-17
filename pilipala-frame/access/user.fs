namespace pilipala.access.user

open System
open System.Collections
open System.Collections.Generic
open fsharper.typ
open fsharper.alias
open pilipala.container.post
open pilipala.container.comment

/// 用户数据
/// 此类型仅面向底层公开，负责临时装载非映射数据
type UserData =
    { Id: i64
      Name: string
      Email: string
      CreateTime: DateTime
      AccessTime: DateTime
      Permission: u16
      Props: Map<string, obj> }
    member self.Item name =
        self.Props.TryGetValue(name).intoOption' ()

    interface IEnumerable<KeyValuePair<string, obj>> with
        member i.GetEnumerator() =
            (i.Props :> IEnumerable).GetEnumerator()

        member i.GetEnumerator() =
            (i.Props :> IEnumerable<_>).GetEnumerator()

/// 用户映射
/// 此类型面向底层公开，负责同步性更改数据库条目
type IMappedUser =
    abstract Id: i64
    abstract Name: string with get, set
    abstract Email: string with get, set
    abstract CreateTime: DateTime with get, set
    abstract AccessTime: DateTime with get, set
    abstract Permission: u16 with get, set
    abstract Item: string -> Option'<obj> with get, set

(*
    abstract GetPost: id: i64 -> Result'<IPost, string>
    abstract NewPost: title: string * body: string -> Result'<IPost, string>
    abstract NewCommentOn: IPost * body: string -> Result'<IComment, string>
    abstract NewCommentOn: IComment * body: string -> Result'<IComment, string>
*)

type IMappedUserProvider =
    abstract fetch: i64 -> IMappedUser
    abstract create: UserData -> IMappedUser
    abstract delete: i64 -> UserData

type LoginData = { userName: string; userPwd: string }
(*
*)
