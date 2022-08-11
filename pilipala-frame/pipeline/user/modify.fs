namespace pilipala.pipeline.user

open System
open System.Collections.Generic
open fsharper.alias
open fsharper.typ
open pilipala.pipeline

type IUserModifyPipelineBuilder =
    abstract Name: BuilderItem<i64 * string>
    abstract Email: BuilderItem<i64 * string>
    abstract CreateTime: BuilderItem<i64 * DateTime>
    abstract AccessTime: BuilderItem<i64 * DateTime>
    abstract Permission: BuilderItem<i64 * u16>
    abstract Item: string -> BuilderItem<i64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<i64 * obj>>>

type IUserModifyPipeline =
    abstract Name: (i64 * string) -> i64 * string
    abstract Email: (i64 * string) -> i64 * string
    abstract CreateTime: (i64 * DateTime) -> i64 * DateTime
    abstract AccessTime: (i64 * DateTime) -> i64 * DateTime
    abstract Permission: (i64 * u16) -> i64 * u16
    abstract Item: string -> Option'<i64 * obj -> i64 * obj>
