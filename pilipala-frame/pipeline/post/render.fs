namespace pilipala.pipeline.post

open System
open System.Collections.Generic
open fsharper.typ
open fsharper.alias
open pilipala.pipeline

type IPostRenderPipelineBuilder =
    abstract Title: BuilderItem<i64, i64 * string>
    abstract Body: BuilderItem<i64, i64 * string>
    abstract CreateTime: BuilderItem<i64, i64 * DateTime>
    abstract AccessTime: BuilderItem<i64, i64 * DateTime>
    abstract ModifyTime: BuilderItem<i64, i64 * DateTime>
    abstract UserId: BuilderItem<i64, i64 * i64>
    abstract Permission: BuilderItem<i64, i64 * u8>
    abstract Item: string -> BuilderItem<i64, i64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<i64, i64 * obj>>>

type IPostRenderPipeline =
    abstract Title: i64 -> i64 * string
    abstract Body: i64 -> i64 * string
    abstract CreateTime: i64 -> i64 * DateTime
    abstract AccessTime: i64 -> i64 * DateTime
    abstract ModifyTime: i64 -> i64 * DateTime
    abstract UserId: i64 -> i64 * i64
    abstract Permission: i64 -> i64 * u8
    abstract Item: string -> Option'<i64 -> i64 * obj>
