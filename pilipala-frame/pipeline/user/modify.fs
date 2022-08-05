namespace pilipala.pipeline.user

open System
open System.Collections.Generic
open fsharper.op.Alias
open fsharper.typ
open pilipala.pipeline

type IUserModifyPipelineBuilder =
    abstract Name: BuilderItem<u64 * string>
    abstract Email: BuilderItem<u64 * string>
    abstract CreateTime: BuilderItem<u64 * DateTime>
    abstract AccessTime: BuilderItem<u64 * DateTime>
    abstract Permission: BuilderItem<u64 * u16>
    abstract Item: string -> BuilderItem<u64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<u64 * obj>>>

type IUserModifyPipeline =
    abstract Name: (u64 * string) -> u64 * string
    abstract Email: (u64 * string) -> u64 * string
    abstract CreateTime: (u64 * DateTime) -> u64 * DateTime
    abstract AccessTime: (u64 * DateTime) -> u64 * DateTime
    abstract Permission: (u64 * u16) -> u64 * u16
    abstract Item: string -> Option'<u64 * obj -> u64 * obj>
