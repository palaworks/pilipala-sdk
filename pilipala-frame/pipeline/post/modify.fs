namespace pilipala.pipeline.post

open System
open System.Collections.Generic
open fsharper.op.Alias
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
