open canopy
open Example
open SkillChecking

elementTimeout <- 2.0
chromeDir <- __SOURCE_DIRECTORY__
start chrome

runExample
//runSkillChecking

run()
System.Console.WriteLine("Press any key to continue")
System.Console.ReadLine() |> ignore
quit()