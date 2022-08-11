namespace pilipala.pipeline.comment

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.container.comment

type ICommentFinalizePipelineBuilder =
    abstract Batch: BuilderItem<i64, CommentData>

type ICommentFinalizePipeline =
    abstract Batch: i64 -> CommentData
