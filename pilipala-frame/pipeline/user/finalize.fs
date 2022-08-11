namespace pilipala.pipeline.user

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.access.user

type IUserFinalizePipelineBuilder =
    abstract Batch: BuilderItem<i64, UserData>

type IUserFinalizePipeline =
    abstract Batch: i64 -> UserData
