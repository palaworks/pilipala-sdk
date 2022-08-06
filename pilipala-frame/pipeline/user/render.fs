namespace pilipala.pipeline.user

open System
open System.Collections.Generic
open System.Security
open fsharper.alias
open fsharper.typ.Option'
open pilipala.pipeline

type IUserRenderPipelineBuilder =
    abstract Name: BuilderItem<u64, u64 * string>
    abstract Email: BuilderItem<u64, u64 * string>
    abstract CreateTime: BuilderItem<u64, u64 * DateTime>
    abstract AccessTime: BuilderItem<u64, u64 * DateTime>
    abstract Permission: BuilderItem<u64, u64 * u16>
    abstract Item: string -> BuilderItem<u64, u64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<u64, u64 * obj>>>

type IUserRenderPipeline =
    abstract Name: u64 -> u64 * string
    abstract Email: u64 -> u64 * string
    abstract CreateTime: u64 -> u64 * DateTime
    abstract AccessTime: u64 -> u64 * DateTime
    abstract Permission: u64 -> u64 * u16
    abstract Item: string -> Option'<u64 -> u64 * obj>
