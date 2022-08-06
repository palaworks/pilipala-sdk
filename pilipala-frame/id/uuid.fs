namespace pilipala.id

open fsharper.alias

type IUuidGenerator =
    abstract member next: unit -> string
