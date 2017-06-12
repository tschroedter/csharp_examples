Feature: CardsRankEngine
         The engine is used to rank a set of 5 cards.

@straightFlush
Scenario: Engine detects straight flush
       Given I added a card 'two of clubs' to player cards
       And I added a card 'three of clubs' to player cards
       And I added a card 'four of clubs' to player cards
       And I added a card 'five of clubs' to player cards
       And I added a card 'six of clubs' to player cards
       When I apply the rules
       Then the status should be 'StraightFlush'
       And the HighestCard should be 'six of Clubs'

@fourOfAKind
Scenario: Engine detects four of a kind
       Given I added a card 'two of clubs' to player cards
       And I added a card 'two of spades' to player cards
       And I added a card 'two of hearts' to player cards
       And I added a card 'two of diamonds' to player cards
       And I added a card 'six of Clubs' to player cards
       When I apply the rules
       Then the status should be 'FourOfAKind'
       And the HighestCard should be 'six of Clubs'
       And the FourOfAKind should be 'two of clubs, two of spades, two of hearts, two of diamonds'
       And the Rank should be 'two'
