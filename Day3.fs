module AoC.Day3

    open System.IO 
    open General 
    let fileName = "day3.input"
    
    let getItems file =
        let lines = General.readInput file
        lines
            |> List.map (fun it ->
                            let n = it.Length/2 

                            (System.String(it.ToCharArray() |> Array.take n),
                             System.String(it.ToCharArray() |> Array.skip n))
                        )
    
    let rec getCommonChar (charList: char list) (str2:string) =
        match charList with
        | h :: t ->
            if String.exists (fun c -> c = h) str2 then
                h
            else
                getCommonChar t str2 
        | [] ->
            raise (invalidArg "List" "List cannot be empty")
    
    let priority (c: char) =
        if (System.Char.IsLower c) then
            int c - int 'a' + 1
        else
            int c - int 'A' + 27
        
            
    let getRepeatedItem items =
        items
        |> List.map (fun (s1,s2) -> getCommonChar (s1 |> Seq.toList) s2 )
        
    let getPoints items =
        items
        |> getRepeatedItem
        |> List.map priority
        |> List.sum 
        

    module Part2 =
        
        let getItems file =
            let lines = General.readInput file
            let n = lines.Length/3 
            lines
                |> List.splitInto n 
                
                
        let rec getCommonChar (charList: char list) (str2:string) (str3: string) =
            match charList with
            | h :: t ->
                if String.exists (fun c -> c = h) str2 &&
                   String.exists (fun c -> c = h) str3 
                then
                    h
                else
                    getCommonChar t str2 str3
            | [] ->
                raise (invalidArg "List" "List cannot be empty")
                        
        let getRepeatedItem (items: string list list ) =
            items
            |> List.map (fun s -> getCommonChar (s.[0] |> Seq.toList) s.[1] s.[2] )
            
        let getPoints items =
            items
            |> getRepeatedItem
            |> List.map priority
            |> List.sum 
                            