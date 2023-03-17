:- discontiguous male/1.
:- discontiguous female/1.
:- discontiguous parent/2.

female(a0).

male(a1).

female(a2).

male(a3).

female(b0).
parent(a0,b0).
parent(a1,b0).

male(b1).
parent(a2,b1).
parent(a3,b1).

female(c0).

male(c1).
parent(b0,c1).
parent(b1,c1).

male(c2).
parent(b0,c2).
parent(b1,c2).

female(c3).
parent(b0,c3).
parent(b1,c3).

male(c4).

male(d0).
parent(c0,d0).
parent(c1,d0).

female(d1).
parents(c0,c1,d1).
parent(c0,d1).
parent(c1,d1).

female(d2).
parent(c0,d2).
parent(c1,d2).

male(d3).

female(d4).

male(d5).
parent(c3,d5).
parent(c4,d5).


female(d6).
parent(c3,d6).
parent(c4,d6).


female(e0).
parent(d2,e0).
parent(d3,e0).


male(e1).
parent(d2,e1).
parent(d3,e1).

female(e2).
parent(d4,e2).
parent(d5,e2).

male(e3).
parent(d4,e3).
parent(d5,e3).


grandparent(X, Z) :- parent(X, Y), parent(Y, Z).
son(X) :- male(X), parent(_, X).
daughter(X) :- female(X), parent(_, X).
siblings(X,Y) :- parent(Z,X), parent(Z,Y), X\==Y.
greatgrandparent(X,Z) :- parent(X, Y), grandparent(Y,Z).
auncle(X,Y) :- siblings(X,Z), parent(Z,Y).
nephew(Y,X) :- male(Y), auncle(X,Y).