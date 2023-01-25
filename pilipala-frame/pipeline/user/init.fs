namespace pilipala.pipeline.user

open fsharper.alias
open pilipala.pipeline
open pilipala.access.user

type IUserInitPipelineBuilder =
    abstract Batch: BuilderItem<UserData, i64>

type IUserInitPipeline =
    abstract Batch: UserData -> i64
