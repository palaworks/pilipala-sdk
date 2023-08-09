namespace pilipala.pipeline.comment

open fsharper.alias
open pilipala.pipeline
open pilipala.container.comment

type ICommentInitPipelineBuilder =
    abstract Batch: BuilderItem<CommentData, i64>

type ICommentInitPipeline =
    abstract Batch: CommentData -> i64
