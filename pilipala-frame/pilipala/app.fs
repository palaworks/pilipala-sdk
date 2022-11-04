namespace pilipala

open fsharper.op
open fsharper.typ
open fsharper.alias
open pilipala.access.user

type IApp =
    abstract userLoginById: user_id: i64 -> user_pwd: string -> Result'<IUser, string>
    abstract userLoginByName: user_name: string -> user_pwd: string -> Result'<IUser, string>
