namespace pilipala.pipeline.user

open System
open System.Collections.Generic
open System.Security
open fsharper.alias
open fsharper.typ.Option'
open pilipala.pipeline

type IUserRenderPipelineBuilder =
    abstract Name: BuilderItem<i64, i64 * string>
    abstract Email: BuilderItem<i64, i64 * string>
    abstract CreateTime: BuilderItem<i64, i64 * DateTime>
    abstract AccessTime: BuilderItem<i64, i64 * DateTime>
    abstract Permission: BuilderItem<i64, i64 * u16>
    abstract Item: string -> BuilderItem<i64, i64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<i64, i64 * obj>>>

type IUserRenderPipeline =
    abstract Name: i64 -> i64 * string
    abstract Email: i64 -> i64 * string
    abstract CreateTime: i64 -> i64 * DateTime
    abstract AccessTime: i64 -> i64 * DateTime
    abstract Permission: i64 -> i64 * u16
    abstract Item: string -> Option'<i64 -> i64 * obj>
