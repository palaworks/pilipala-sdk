namespace pilipala.pipeline.user

open System
open fsharper.alias
open pilipala.pipeline
open pilipala.access.user

type IUserInitPipelineBuilder =
    abstract Batch: BuilderItem<UserData, u64>

type IUserInitPipeline =
    abstract Batch: UserData -> u64
