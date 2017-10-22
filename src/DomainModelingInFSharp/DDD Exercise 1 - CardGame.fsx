// ================================================
// DDD Exercise: Model a card game
//
// ================================================

(*

=== NOUNS ===

A card is a combination of a Suit (Heart, Spade) and a Rank (Two, Three, ... King, Ace)

A hand is a list of cards

A deck  is a list of cards

A player has a name and a hand

A game consists of a deck and list of players

=== VERBS ===

To shuffle a deck, start with any deck, afterwards, you have a shuffled deck. 
type = Deck

To deal, start with a shuffled deck, afterwards, you have a new shuffled deck and a card on the table

To pick up a card, start with your hand and a card on the table, , afterwards, you have a new hand

*)

module CardGame =

    type Suit = 
        | Heart
        | Spade
        | Club
        | Diamond  // you take it from here!
    type Rank = 
        | Two
        | Three
        | Four
        | Five
        | Six
        | Seven
        | Eight
        | Nine
        | Ten
        | Jack
        | King
        | Queen
        | Ace
    type Card = Suit * Rank

    type Hand = Card list
    type Deck = Card list

    type Player = {Name : string; Hand : Hand}
    type Game = {Deck : Deck; Players : Player list}
    type ShuffledDeck = ShuffledDeck of Deck

    type Shuffle = Deck -> ShuffledDeck   // Do you need to create a new noun? I wouldnt have done this but it is a good idea because it clarifies what is happening
    type Deal = ShuffledDeck -> ShuffledDeck * Card option
    type PickupCard = Hand * Card -> Hand


    let deal : Deal =
        fun (ShuffledDeck cards) ->
            match cards with
            | dealtCard::remaining -> (ShuffledDeck remaining, Some dealtCard)
            | [] -> (ShuffledDeck)