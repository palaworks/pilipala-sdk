namespace pilipala.pipeline.comment

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.container.comment

type ICommentFinalizePipelineBuilder =
    abstract Batch: BuilderItem<u64, CommentData>

type ICommentFinalizePipeline =
    abstract Batch: u64 -> CommentData
