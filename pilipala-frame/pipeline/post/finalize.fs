namespace pilipala.pipeline.post

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.container.post

type IPostFinalizePipelineBuilder =
    abstract Batch: BuilderItem<i64, PostData>

type IPostFinalizePipeline =
    abstract Batch: i64 -> PostData
