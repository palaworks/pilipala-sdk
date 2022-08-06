namespace pilipala.pipeline.user

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.access.user

type IUserFinalizePipelineBuilder =
    abstract Batch: BuilderItem<u64, UserData>

type IUserFinalizePipeline =
    abstract Batch: u64 -> UserData
