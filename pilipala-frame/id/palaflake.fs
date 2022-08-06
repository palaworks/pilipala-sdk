namespace pilipala.id

open fsharper.alias

type IPalaflakeGenerator =
    abstract member next: unit -> u64
