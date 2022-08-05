namespace pilipala.pipeline.post

open System
open System.Collections.Generic
open fsharper.op.Alias
open fsharper.typ
open pilipala.pipeline

type IPostModifyPipelineBuilder =
    abstract Title: BuilderItem<u64 * string>
    abstract Body: BuilderItem<u64 * string>
    abstract CreateTime: BuilderItem<u64 * DateTime>
    abstract AccessTime: BuilderItem<u64 * DateTime>
    abstract ModifyTime: BuilderItem<u64 * DateTime>
    abstract UserId: BuilderItem<u64 * u64>
    abstract Permission: BuilderItem<u64 * u16>
    abstract Item: string -> BuilderItem<u64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<u64 * obj>>>

type IPostModifyPipeline =
    abstract Title: (u64 * string) -> u64 * string
    abstract Body: (u64 * string) -> u64 * string
    abstract CreateTime: (u64 * DateTime) -> u64 * DateTime
    abstract AccessTime: (u64 * DateTime) -> u64 * DateTime
    abstract ModifyTime: (u64 * DateTime) -> u64 * DateTime
    abstract UserId: (u64 * u64) -> u64 * u64
    abstract Permission: (u64 * u16) -> u64 * u16
    abstract Item: string -> Option'<u64 * obj -> u64 * obj>
