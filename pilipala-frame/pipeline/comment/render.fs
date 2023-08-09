namespace pilipala.pipeline.comment

open System
open System.Collections.Generic
open fsharper.typ
open fsharper.alias
open pilipala.container.comment
open pilipala.pipeline

type ICommentRenderPipelineBuilder =
    abstract Body: BuilderItem<i64, i64 * string>
    abstract Binding: BuilderItem<i64, i64 * CommentBinding>
    abstract CreateTime: BuilderItem<i64, i64 * DateTime>
    abstract ModifyTime: BuilderItem<i64, i64 * DateTime>
    abstract UserId: BuilderItem<i64, i64 * i64>
    abstract Permission: BuilderItem<i64, i64 * u8>
    abstract Item: string -> BuilderItem<i64, i64 * obj>

    //用于遍历Item
    inherit IEnumerable<KeyValuePair<string, BuilderItem<i64, i64 * obj>>>

type ICommentRenderPipeline =
    abstract Body: i64 -> i64 * string
    abstract Binding: i64 -> i64 * CommentBinding
    abstract CreateTime: i64 -> i64 * DateTime
    abstract ModifyTime: i64 -> i64 * DateTime
    abstract UserId: i64 -> i64 * i64
    abstract Permission: i64 -> i64 * u8
    abstract Item: string -> Option'<i64 -> i64 * obj>
