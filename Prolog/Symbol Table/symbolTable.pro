add([[A | B] | C], Name, Category, Type, Value, []).	
add([], Name, Category, Type, Value, [[Name, Category, Type, Value]]).
add([A | RofT], Name, Category, Type, Value, [[Name, Category, Type, Value] | [A | RofT]]) :- 
	addR(RofT, Name, Category, Type, Value, NewTable). 


addR([[A | B] | C], Name, Category, Type, Value, []). 	
addR([], Name, Category, Type, Value, NewTable).
addR([A | RofT], Name, Category, Type, Value, NewTable) :- 
	addR(RofT, Name, Category, Type, Value, NewTable).

entry([[Name, Category, Type, Value] | RofT], Name, Category, Type, Value).
entry([A| RofT], Name, Category, Type, Value) :-
	entry(RofT, Name, Category, Type, Value).

category([[Name | [Category | C]] | D], Name, Category).
category([A | RofT], Name, Category) :-
	 category(RofT, Name, Category). 

type([[Name | [B | [Type | D]]] | E], Name, Type).
type([A | RofT], Name, Type) :-
	 type(RofT, Name, Type). 

value([[Name, B, C, Value] | F], Name, Value).
value([A | RofT], Name, Value) :-
	 value(RofT, Name, Value). 