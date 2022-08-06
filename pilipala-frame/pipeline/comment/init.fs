namespace pilipala.pipeline.comment

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.container.comment

type ICommentInitPipelineBuilder =
    abstract Batch: BuilderItem<CommentData, u64>

type ICommentInitPipeline =
    abstract Batch: CommentData -> u64
