namespace pilipala.id

type IUuidGenerator =
    abstract member next: unit -> string
