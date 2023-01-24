module AoC.Day5

    open System.IO 
    open General
    open Microsoft.FSharp.Core 
    let fileName = "day5.input"
    
    type Range =
        {
            Start: int
            End: int 
        }
        
    type Move =
        {
            From : int
            To : int
            HowMany : int 
        }
            
    let getItems file =
        let l = General.readInput file
        let n = l |> List.findIndex (fun s -> s = "")
        let crates, moves = l |> List.splitAt n
        crates, moves |> List.tail 
        
            // |> List.map (fun s ->
            //                 let l = s.Split(',')
            //                         |> Array.map strToRange 
            //                 (l[0],l[1]))
    
    let chunkByThree (str: string) =
        
        let idx = 3
        let rec loop (inStr: string) outList =
            if System.String.IsNullOrEmpty(inStr)
            then 
                outList
            else  
                let s = inStr.[0..idx-1]
                let tail = inStr.[idx+1..] 
                
                let nextList =  List.append outList [s] 
                loop tail nextList 
                 
        loop str []    
        
    let getMove (str: string) =
        let s = str.Split(" from ")
        let m = s[1].Split(" to ")
        {
            From = (m[0] |> int )- 1 
            To = (m[1] |> int) - 1 
            HowMany = s[0].Split("move ").[1] |> int           
        }
            
            
    let getCrates crates =
        let l = crates
                |> List.take (crates.Length-1)
                |> List.map chunkByThree
                |> List.transpose
                |> List.map List.rev
                |> List.map ( fun l -> l |> List.filter (fun s -> s <> "   " ))
                |> List.indexed
                |> Map.ofList 
                
        l
        
    let getMoves moves =
        moves
        |> List.map getMove
        

    let moveCrates (crates: Map<int,string list>) (move: Move) =
        let nFrom = crates.[move.From].Length - move.HowMany 
        let nextFrom, moving = crates.[move.From] |> List.splitAt nFrom
        let nextTo = crates[move.To] @ (moving |> List.rev) 
        crates
        |> Map.add move.To nextTo
        |> Map.add move.From nextFrom 
        
    let rec moveAll crates (moves: Move list) =

        match moves with
        | [] -> crates
        | m :: t ->
            let newCrates = moveCrates crates m 
            moveAll newCrates t
            
    let getTopCrates (crates: Map<int,string list>) =
        crates
        |> Map.map (fun k l -> l |> List.rev |> List.head)
        |> Map.toList
        |> List.map snd
        |> List.map (fun s -> s |> String.filter System.Char.IsLetter )
        |> List.fold (fun a s -> a + s) ""
        
        