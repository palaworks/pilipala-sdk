namespace pilipala.access.user

open System
open System.Collections
open System.Collections.Generic
open System.Windows.Input
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

type IUser =

    abstract ReadPermissionLv: u16
    abstract WritePermissionLv: u16
    abstract CommentPermissionLv: u16
    abstract ReadUserPermissionLv: u16
    abstract WriteUserPermissionLv: u16

    abstract Id: i64
    abstract Name: string
    abstract Email: string
    abstract CreateTime: DateTime
    abstract AccessTime: DateTime
    abstract Permission: u16
    abstract Item: string -> Option'<obj>

    abstract GetUser: i64 -> Result'<IUser, string>
    abstract GetPost: i64 -> Result'<IPost, string>
    abstract GetComment: i64 -> Result'<IComment, string>

    abstract UpdateName: string -> Result'<unit, string>
    abstract UpdateEmail: string -> Result'<unit, string>
    abstract UpdatePermission: u16 -> Result'<unit, string>
    abstract UpdateItem: string -> obj -> Result'<unit, string>

    abstract GetReadablePost: unit -> IPost seq
    abstract GetWritablePost: unit -> IPost seq
    abstract GetCommentablePost: unit -> IPost seq

    abstract GetReadableComment: unit -> IComment seq
    abstract GetWritableComment: unit -> IComment seq
    abstract GetCommentableComment: unit -> IComment seq

    abstract NewUser: string -> string -> u16 -> Result'<IUser, string>
    abstract NewPost: string -> string -> Result'<IPost, string>
    abstract Drop: unit -> Result'<UserData, string>
