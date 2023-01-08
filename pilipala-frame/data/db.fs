namespace pilipala.data.db

open System.Data.Common
open System.Threading.Tasks
open fsharper.typ
open fsharper.alias

type DbConfig =
    { connection: {| host: string //考虑到后续可能换用其他控制器，此处与DbManaged不作耦合
                     port: u16
                     usr: string
                     pwd: string
                     using: string |}
      pooling: {| size: u16; sync: u16 |}
      map: {| post: string
              comment: string
              user: string |} }

type IDbOperationBuilder =

    /// 命令行生成器
    abstract makeCmd: unit -> DbCommand

    [<CustomOperation("execute")>]
    abstract execute: (DbConnection -> 'r) -> 'r

    [<CustomOperation("executeAsync")>]
    abstract executeQueryAsync: (DbConnection -> Task<'r>) -> Task<'r>

    [<CustomOperation("queue")>]
    abstract queue: (DbConnection -> 'r) -> Task<'r>

    [<CustomOperation("delay")>]
    abstract delay: (DbConnection -> 'r) -> Task<'r>

    /// 表集合
    abstract tables:
        {| post: string
           comment: string
           user: string |}
