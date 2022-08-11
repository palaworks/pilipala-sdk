namespace pilipala.pipeline.post

open System
open System.Collections.Generic
open fsharper.alias
open fsharper.typ
open pilipala.pipeline

type IPostModifyPipelineBuilder =
    abstract Title: BuilderItem<i64 * string>
    abstract Body: BuilderItem<i64 * string>
    abstract CreateTime: BuilderItem<i64 * DateTime>
    abstract AccessTime: BuilderItem<i64 * DateTime>
    abstract ModifyTime: BuilderItem<i64 * DateTime>
    abstract UserId: BuilderItem<i64 * i64>
    abstract Permission: BuilderItem<i64 * u8>
    abstract Item: string -> BuilderItem<i64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<i64 * obj>>>

type IPostModifyPipeline =
    abstract Title: (i64 * string) -> i64 * string
    abstract Body: (i64 * string) -> i64 * string
    abstract CreateTime: (i64 * DateTime) -> i64 * DateTime
    abstract AccessTime: (i64 * DateTime) -> i64 * DateTime
    abstract ModifyTime: (i64 * DateTime) -> i64 * DateTime
    abstract UserId: (i64 * i64) -> i64 * i64
    abstract Permission: (i64 * u8) -> i64 * u8
    abstract Item: string -> Option'<i64 * obj -> i64 * obj>
