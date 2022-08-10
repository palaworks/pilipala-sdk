namespace pilipala.pipeline.comment

open System
open System.Collections.Generic
open fsharper.alias
open fsharper.typ
open pilipala.pipeline
open pilipala.container.comment

type ICommentModifyPipelineBuilder =
    abstract Body: BuilderItem<u64 * string>
    abstract Binding: BuilderItem<u64 * CommentBinding>
    abstract CreateTime: BuilderItem<u64 * DateTime>
    abstract UserId: BuilderItem<u64 * u64>
    abstract Permission: BuilderItem<u64 * u8>
    abstract Item: string -> BuilderItem<u64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<u64 * obj>>>

type ICommentModifyPipeline =
    abstract Body: (u64 * string) -> u64 * string
    abstract Binding: (u64 * CommentBinding) -> u64 * CommentBinding
    abstract CreateTime: (u64 * DateTime) -> u64 * DateTime
    abstract UserId: (u64 * u64) -> u64 * u64
    abstract Permission: (u64 * u8) -> u64 * u8
    abstract Item: string -> Option'<u64 * obj -> u64 * obj>
