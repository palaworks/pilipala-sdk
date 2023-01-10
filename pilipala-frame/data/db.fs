namespace pilipala.data.db

open System.Data.Common
open System.Threading.Tasks
open fsharper.typ
open fsharper.alias

type DbConfig = //考虑到后续可能换用其他控制器，此处与DbManaged不作耦合
    { connection: {| host: string
                     port: u16
                     usr: string
                     pwd: string |}
      definition: {| name: string
                     post: string
                     comment: string
                     user: string |}
      performance: {| pooling: u16 |} }

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
        {| user: string
           post: string
           comment: string |}
