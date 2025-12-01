module FSharp.Utilities

open System.IO

let GetLeftAndRightLists filePath =
    File.ReadLines(filePath)