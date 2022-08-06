namespace pilipala.pipeline.post

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.container.post

type IPostFinalizePipelineBuilder =
    abstract Batch: BuilderItem<u64, PostData>

type IPostFinalizePipeline =
    abstract Batch: u64 -> PostData
