module AoC.Day2

    open AoC.General
    
    open System.IO 
    
    let fileName = "day2.input"
    
    type RPS =
        | Rock
        | Paper
        | Scissors
        member this.points () =
            match this with 
                | Rock -> 1
                | Paper -> 2
                | Scissors -> 3
                
    type Point =
        | Won
        | Draw
        | Lost 
        member this.points () =
            match this with 
                | Won -> 6
                | Draw -> 3
                | Lost -> 0                
                
    let points2 rps1 rps2 =
        match rps1,rps2 with
        | Rock, Paper -> Won 
        | Rock, Scissors -> Lost
        | Paper, Rock -> Lost 
        | Paper, Scissors -> Won
        | Scissors, Rock -> Won
        | Scissors, Paper -> Lost 
        | _ -> Draw
        
    
    let fromChar c =
            match c with
            | "A" | "X" -> Rock
            | "B" | "Y" -> Paper
            | "C" | "Z" -> Scissors
            | _ -> raise (invalidArg "Char" "InvalidArgument")
                        
    
    let readInput file =
        let lines = File.ReadLines(Path.Combine(General.aocPath,file))
                    |> Seq.toList
        lines 
    
    let roundsPart1 file =
        readInput file 
        // lines
        |> List.map (fun s ->
                        let q = s.Split()
                        (q[0] |> fromChar,
                         q[1] |> fromChar)
                    )
        
    
    // Part 2 
    let rules2 (a, c) =
        match (a,c) with
            | Rock, "X" -> Scissors
            | Paper, "Y" -> Paper
            | Scissors, "Z" -> Rock 
            | Rock, "Y" -> Rock
            | Paper, "Z" -> Scissors
            | Scissors, "X" -> Paper 
            | Rock, "Z" -> Paper 
            | Paper, "X" -> Rock 
            | Scissors, "Y" -> Scissors            
            | _ -> raise (invalidArg "Char" "InvalidArgument")
              
    
    let roundsPart2 file =
        readInput file 
        // lines
        |> List.map (fun s ->
                        let q = s.Split()
                        let play = (q[0] |> fromChar, q[1] ) |> rules2
                        (q[0] |> fromChar ,play)
                    )
                            
    let getPoints (rpss: (RPS * RPS) list) =
        rpss
        |> List.map (fun  (rps1,rps2) ->
                        let round = points2 rps1 rps2
                        round.points() + rps2.points() 
                        )
        |> List.sum 
        
                