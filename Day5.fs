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
        let rec loop n (inStr: string) outList =
            if System.String.IsNullOrEmpty(inStr)
            then 
                outList
            else  
                let s = inStr.[0..idx-1]
                let tail = inStr.[idx+1..] 
                
                let nextList =  List.append outList [s] 
                loop (n+1) tail nextList 
                 
        loop 0 str []    
        
    let getMove (str: string) =
        let s = str.Split(" from ")
        let m = s[1].Split(" to ")
        {
            From = m[0] |> int
            To = m[1] |> int
            HowMany = s[0].Split("move ").[1] |> int           
        }
            
            
    let getCrates crates =
        let l = crates
                |> List.take (crates.Length-1)
                |> List.map chunkByThree
                |> List.transpose
                |> List.map List.rev
                
        l
        
    let getMoves moves =
        moves
        |> List.map getMove 