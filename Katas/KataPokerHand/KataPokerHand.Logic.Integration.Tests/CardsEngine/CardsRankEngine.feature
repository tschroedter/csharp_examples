Feature: CardsRankEngine
         The engine is used to rank a set of 5 cards.

@straightFlush
Scenario: Engine detects StraightFlush
       Given I added a card 'two of Clubs' to player cards
       And I added a card 'three of Clubs' to player cards
       And I added a card 'four of Clubs' to player cards
       And I added a card 'five of Clubs' to player cards
       And I added a card 'six of Clubs' to player cards
       When I apply the rules
       Then the status should be 'Straight Flush'