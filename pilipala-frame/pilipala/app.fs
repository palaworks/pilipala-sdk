namespace pilipala

open fsharper.op
open fsharper.typ
open fsharper.alias
open pilipala.access.user

type IApp =
    //TODO para name
    abstract userLoginById: i64 -> string -> Result'<IUser, string>
    abstract userLoginByName: string -> string -> Result'<IUser, string>
