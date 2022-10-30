[<AutoOpen>]
module pilipala.data.db.ext_IDbOperationBuilder

open System.Data.Common
open fsharper.op
open fsharper.typ
open DbManaged
open DbManaged.PgSql
open pilipala.data.db

type IDbOperationBuilder with
    member db.Yield _ = db.makeCmd ()

type IDbOperationBuilder with

    [<CustomOperation("inComment")>]
    member db.inComment cmd = cmd, db.tables.comment

    [<CustomOperation("inPost")>]
    member db.inPost cmd = cmd, db.tables.post

    [<CustomOperation("inToken")>]
    member db.inToken cmd = cmd, db.tables.token

    [<CustomOperation("inUser")>]
    member db.inUser cmd = cmd, db.tables.user

type IDbOperationBuilder with

    [<CustomOperation("insert")>]
    member db.insert((cmd, table), fields) = (cmd: DbCommand).insert (table, fields)

    [<CustomOperation("select")>]
    member db.select(cmd, sql, paras) = (cmd: DbCommand).select (sql, paras)

    [<CustomOperation("update")>]
    member db.update((cmd, table), targetKey, targetVal, whereKey, whereVal) =
        (cmd: DbCommand)
            .update (table, (targetKey, targetVal), (whereKey, whereVal))

    [<CustomOperation("delete")>]
    member db.delete((cmd, table), whereKey, whereVal) =
        (cmd: DbCommand)
            .delete (table, whereKey, whereVal)

type IDbOperationBuilder with

    [<CustomOperation("getFstVal")>]
    member db.getFstVal(cmd, sql, paras) = (cmd: DbCommand).getFstVal (sql, paras)

    [<CustomOperation("getFstVal")>]
    member db.getFstVal((cmd, table), targetKey, whereKey, whereVal) =
        (cmd: DbCommand)
            .getFstVal (table, targetKey, whereKey, whereVal)

    [<CustomOperation("getFstRow")>]
    member db.getFstRow((cmd, table), whereKey, whereVal) =
        (cmd: DbCommand)
            .getFstRow (table, whereKey, whereVal)

    [<CustomOperation("getFstRow")>]
    member db.getFstRow(cmd, sql, paras) = (cmd: DbCommand).getFstRow (sql, paras)

    [<CustomOperation("getFstCol")>]
    member db.getFstCol(cmd, sql, paras) = (cmd: DbCommand).getFstCol (sql, paras)

type IDbOperationBuilder with

    [<CustomOperation("whenEq")>]
    member db.whenEq(f, n) = f (eq n)

    [<CustomOperation("alwaysCommit")>]
    member db.always f = f (always true)
