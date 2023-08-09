namespace pilipala.pipeline.post

open fsharper.alias
open pilipala.pipeline
open pilipala.container.post

type IPostInitPipelineBuilder =
    abstract Batch: BuilderItem<PostData, i64>

type IPostInitPipeline =
    abstract Batch: PostData -> i64
