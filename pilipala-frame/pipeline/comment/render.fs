namespace pilipala.pipeline.comment

open System
open System.Collections.Generic
open fsharper.typ
open fsharper.alias
open pilipala.container.comment
open pilipala.pipeline

type ICommentRenderPipelineBuilder =
    abstract Body: BuilderItem<u64, u64 * string>
    abstract Binding: BuilderItem<u64, u64 * CommentBinding>
    abstract CreateTime: BuilderItem<u64, u64 * DateTime>
    abstract UserId: BuilderItem<u64, u64 * u64>
    abstract Permission: BuilderItem<u64, u64 * u16>
    abstract Item: string -> BuilderItem<u64, u64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<u64, u64 * obj>>>

type ICommentRenderPipeline =
    abstract Body: u64 -> u64 * string
    abstract Binding: u64 -> u64 * CommentBinding
    abstract CreateTime: u64 -> u64 * DateTime
    abstract UserId: u64 -> u64 * u64
    abstract Permission: u64 -> u64 * u16
    abstract Item: string -> Option'<u64 -> u64 * obj>
