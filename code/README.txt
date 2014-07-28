Great contest this year!

Language(s) used: The compiler/IDE were written in C# using the IronMeta parser generator to build
a parser for my custom language (GPP). The final solution was written in GPP and compiled using the VisualGpp IDE.

As far as languages go, GPP is pretty dumb. It started out as a plain implementation of the gcc assembly language but
quickly evolved to support function calls, symbolic labels, local variables, if/else control structures, some simple
operators and expressions. Even goto! I'm pretty proud of how my solution evolved from being 99% assembly to almost 
entirely high-level GPP code. You can see the final version of the GPP source in programs/lambdaman.gpp. The
ometa specification for the language can be found in LambdaMan/LambdaMan.Compiler/Gcc.ironmeta.

From programs/lambdaman.gpp:

function consEqual(a, b)
{
	@if((a<< == b<<)) {
		@if((a>> == b>>)) {
			return 1
		} else {
			return 0
		}
	} else {
		return 0
	}
}

The IDE is essentially two large text boxes. The left pane contains the GPP source while the right pane is the compiled
gcc file. Note that recompilation happens automatically in the background whenever the source program changes (ie on 
every keypress :). I was paranoid about losing work so I also had it save a backup on every successful compile (
2997 and counting!). Also note the poor reporting of parser errors and errors in general. Despite all its shortcomings
I still spent almost all my time in this IDE instead of my original plan of using a real editor and pasting into the
IDE when I thought I had something that works. 

IDE in action: https://dl.dropboxusercontent.com/u/26367098/icfp2014/VisualGpp1.png

When I first started the problem I spent most of my time looking at the generated gcc code but as the compiler and
language evolved I found myself spending more and more time working on the actual problem code and less time
adding features to GPP. Most of the final day was spent working in GPP as opposed to c# or gcc.

As far as the solution goes, the basic idea is to use an iterative flood-fill algorithm to generate a "Dijkstra Map"
and then walk from the lambda-man's position to the closes pill (or other wanted item).
I had initially intended on using a classic Dijkstra node traversal but stumbled on
http://www.roguebasin.com/index.php?title=The_Incredible_Power_of_Dijkstra_Maps which seemed to be exactly what I
wanted for the solution. I had never heard of Dijkstra Maps before and that page seems like one of the few 
references for the particular algorithm so it may actually be called something else. In any case after some initial
stumbling blocks of working with cons lists I got it up and running and it seems to perform well. In order to have
some form of ghost avoidance I treat ghosts as walls for the purpose of the pathfinder so my lambdaman will generally
avoid ghosts in his search for pills.

I didn't have time to work on ghost ai as I ran out of steam on Sunday morning so I just used the provided ghost ai
as it seemed to be better than nothing. Maybe next year will be the year I put a team together for this!

Special thanks to Gordon Tisher for IronMeta and to Tim F for allowing me to ramble incoherently at him while I worked!
Thanks to DNA Lounge for live streams and to my family for letting me work on this all weekend!

Quick Stats:

Team size: 1
Compiler: ~3825 lines of code + ~7189 (generated) for the parser
IDE: ~148 lines of code (seriously!)
lambdaman.gpp: ~408 lines of code
lambdaman.gcc: ~867 instructions
Coke Zeros consumed: 10

Instructions for compiling:

Open LambdaMan.sln in some flavor of Visual Studio 2013, set the startup project to VisualGcc and execute. GPP code 
goes in the left pane, gcc code is emitted in the right pane (or a generally unhelpful message if there is a
compilation error). To get started you should be able to paste the contents of programs/lambdaman.gpp into the
code window. Recompilation happens automatically whenever the GPP code window changes.

Tom